using System.Net.Http.Headers;
using EZDotNet.Core.Interfaces;
using EZDotNet.Core.Models.Responses;
using Microsoft.AspNetCore.Http;
using Refit;

namespace EZDotNet.Services.Extension;

/// <summary>
/// Extension methods for the file service interface specifically for ASP.NET Core integration.
/// </summary>
public static class FileServiceExtensions
{
    /// <summary>
    /// Uploads a file from an ASP.NET Core IFormFile.
    /// </summary>
    /// <param name="fileService">The file service instance.</param>
    /// <param name="formFile">The form file to upload.</param>
    /// <returns>A response containing the upload result and file URLs.</returns>
    /// <exception cref="ArgumentException">Thrown when the form file is null or empty.</exception>
    /// <remarks>
    /// This method is specifically designed for ASP.NET Core applications to handle file uploads
    /// from multipart form data requests. It maintains the original content type and filename
    /// from the uploaded file.
    /// </remarks>
    public static async Task<ApiResponse<FileUploadResponse>> UploadFileFromFormFileAsync(
        this IFileService fileService,
        IFormFile formFile)
    {
        if (formFile == null || formFile.Length == 0)
            throw new ArgumentException("The form file is null or empty.", nameof(formFile));

        await using var stream = formFile.OpenReadStream();
        var streamContent = new StreamContent(stream);
        
        streamContent.Headers.ContentType = new MediaTypeHeaderValue(formFile.ContentType);
        streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
        {
            Name = "\"file\"",
            FileName = $"\"{formFile.FileName}\""
        };

        return await fileService.UploadFileAsync(streamContent);
    }
}
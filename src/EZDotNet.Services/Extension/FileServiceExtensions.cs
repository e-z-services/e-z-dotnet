using System.Net.Http.Headers;
using EZDotNet.Core.Interfaces;
using EZDotNet.Core.Models.Responses;
using Microsoft.AspNetCore.Http;
using Refit;

namespace EZDotNet.Services.Extension;

public static class FileServiceExtensions
{
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
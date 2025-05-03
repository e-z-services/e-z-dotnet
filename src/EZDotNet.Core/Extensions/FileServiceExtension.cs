using EZDotNet.Core.Interfaces;
using EZDotNet.Core.Models.Responses;
using Refit;

namespace EZDotNet.Core.Extensions;

using System.Net.Http.Headers;

/// <summary>
/// Extension methods for the file service interface.
/// </summary>
public static class FileServiceExtensions
{
    /// <summary>
    /// Uploads a file from the specified file path.
    /// </summary>
    /// <param name="fileService">The file service instance.</param>
    /// <param name="filePath">The path to the file to upload.</param>
    /// <returns>A response containing the upload result and file URLs.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the specified file does not exist.</exception>
    public static async Task<ApiResponse<FileUploadResponse>> UploadFileFromPathAsync(
        this IFileService fileService,
        string filePath)
    {
        using var content = CreateFileContent(filePath);
        return await fileService.UploadFileAsync(content);
    }

    private static StreamContent CreateFileContent(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("The specified file was not found.", filePath);

        var fileStream = File.OpenRead(filePath);
        var streamContent = new StreamContent(fileStream);
        
        var contentType = Path.GetExtension(filePath).ToLowerInvariant() switch
        {
            ".webp" => "image/webp",
            ".txt" => "text/plain",
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            _ => "application/octet-stream"
        };

        streamContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
        streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
        {
            Name = "\"file\"",
            FileName = $"\"{Path.GetFileName(filePath)}\""
        };

        return streamContent;
    }
}
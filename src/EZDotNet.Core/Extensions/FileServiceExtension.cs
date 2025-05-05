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
    
    /// <summary>
    /// Uploads a file from a byte array.
    /// </summary>
    /// <param name="fileService">The file service instance.</param>
    /// <param name="fileBytes">The byte array containing the file data.</param>
    /// <param name="fileName">The name of the file including extension.</param>
    /// <returns>A response containing the upload result and file URLs.</returns>
    public static async Task<ApiResponse<FileUploadResponse>> UploadFileFromBytesAsync(
        this IFileService fileService,
        byte[] fileBytes,
        string fileName)
    {
        using var content = CreateFileContent(fileBytes, fileName);
        return await fileService.UploadFileAsync(content);
    }

    /// <summary>
    /// Uploads a file from a stream.
    /// </summary>
    /// <param name="fileService">The file service instance.</param>
    /// <param name="stream">The stream containing the file data.</param>
    /// <param name="fileName">The name of the file including extension.</param>
    /// <returns>A response containing the upload result and file URLs.</returns>
    public static async Task<ApiResponse<FileUploadResponse>> UploadFileFromStreamAsync(
        this IFileService fileService,
        Stream stream,
        string fileName)
    {
        using var content = CreateFileContent(stream, fileName);
        return await fileService.UploadFileAsync(content);
    }

    private static StreamContent CreateFileContent(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("The specified file was not found.", filePath);

        var fileStream = File.OpenRead(filePath);
        return CreateFileContent(fileStream, Path.GetFileName(filePath));
    }

    private static StreamContent CreateFileContent(byte[] fileBytes, string fileName)
    {
        var stream = new MemoryStream(fileBytes);
        return CreateFileContent(stream, fileName);
    }

    private static StreamContent CreateFileContent(Stream stream, string fileName)
    {
        var streamContent = new StreamContent(stream);
        var contentType = GetContentType(fileName);

        streamContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
        streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
        {
            Name = "\"file\"",
            FileName = $"\"{fileName}\""
        };

        return streamContent;
    }

    private static string GetContentType(string fileName)
    {
        return Path.GetExtension(fileName).ToLowerInvariant() switch
        {
            // Images
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".webp" => "image/webp",
            ".svg" => "image/svg+xml",
            ".ico" => "image/x-icon",
            ".bmp" => "image/bmp",
            ".tiff" or ".tif" => "image/tiff",

            // Documents
            ".pdf" => "application/pdf",
            ".doc" => "application/msword",
            ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            ".xls" => "application/vnd.ms-excel",
            ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            ".ppt" => "application/vnd.ms-powerpoint",
            ".pptx" => "application/vnd.openxmlformats-officedocument.presentationml.presentation",
            ".odt" => "application/vnd.oasis.opendocument.text",
            ".ods" => "application/vnd.oasis.opendocument.spreadsheet",
            ".odp" => "application/vnd.oasis.opendocument.presentation",

            // Text and Code
            ".txt" => "text/plain",
            ".csv" => "text/csv",
            ".md" => "text/markdown",
            ".html" or ".htm" => "text/html",
            ".css" => "text/css",
            ".js" => "text/javascript",
            ".json" => "application/json",
            ".xml" => "application/xml",
            ".yaml" or ".yml" => "application/yaml",

            // Archives
            ".zip" => "application/zip",
            ".rar" => "application/x-rar-compressed",
            ".7z" => "application/x-7z-compressed",
            ".tar" => "application/x-tar",
            ".gz" => "application/gzip",

            // Audio
            ".mp3" => "audio/mpeg",
            ".wav" => "audio/wav",
            ".ogg" => "audio/ogg",
            ".m4a" => "audio/mp4",
            ".flac" => "audio/flac",

            // Video
            ".mp4" => "video/mp4",
            ".webm" => "video/webm",
            ".avi" => "video/x-msvideo",
            ".mov" => "video/quicktime",
            ".wmv" => "video/x-ms-wmv",
            ".mkv" => "video/x-matroska",

            // Fonts
            ".ttf" => "font/ttf",
            ".otf" => "font/otf",
            ".woff" => "font/woff",
            ".woff2" => "font/woff2",

            // Development
            ".cs" => "text/x-csharp",
            ".java" => "text/x-java-source",
            ".py" => "text/x-python",
            ".php" => "text/x-php",
            ".rb" => "text/x-ruby",
            ".sql" => "text/x-sql",
            ".go" => "text/x-go",
            ".ts" => "text/typescript",

            // Executables and Binaries
            ".exe" => "application/x-msdownload",
            ".dll" => "application/x-msdownload",
            ".so" => "application/x-sharedlib",
            ".apk" => "application/vnd.android.package-archive",

            // Database
            ".db" => "application/x-sqlite3",
            ".mdb" => "application/x-msaccess",
            ".bak" => "application/x-backup",
            
            _ => "application/octet-stream"
        };
    }
}
using EZDotNet.Core.Models.Responses;
using Refit;

namespace EZDotNet.Core.Interfaces;

/// <summary>
/// Provides functionality for interacting with the https://e-z.host file upload service.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Uploads a file to https://e-z.host using multipart form data.
    /// </summary>
    /// <param name="file">The file content to upload.</param>
    /// <returns>A response containing the upload result and file URLs.</returns>
    /// <remarks>
    /// The file will be uploaded using multipart/form-data.
    /// </remarks>
    [Multipart("E-ZHost")]
    [Post("/files")]
    Task<ApiResponse<FileUploadResponse>> UploadFileAsync(
        [AliasAs("file")] StreamContent file);
}
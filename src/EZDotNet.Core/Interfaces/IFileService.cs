using EZDotNet.Core.Models.Responses;
using Refit;

namespace EZDotNet.Core.Interfaces;

public interface IFileService
{
    [Multipart("E-ZHost")]
    [Post("/files")]
    Task<ApiResponse<FileUploadResponse>> UploadFileAsync(
        [AliasAs("file")] StreamContent file);
}
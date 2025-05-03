using EZDotNet.Core.Models.Requests;
using EZDotNet.Core.Models.Responses;
using EZDotNet.Core.Models;
using Refit;

namespace EZDotNet.Core.Interfaces;

public interface IPasteService
{
    [Post("/paste")]
    [Headers("Content-Type: application/json")]
    Task<ApiResponse<PasteCreateResponse>> CreatePasteAsync([Body] PasteCreateRequest request);
}
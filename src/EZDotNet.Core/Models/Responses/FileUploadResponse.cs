using System.Text.Json.Serialization;

namespace EZDotNet.Core.Models.Responses;

public class FileUploadResponse
{
    [JsonPropertyName("success")]
    public required bool Success { get; set; }
    
    [JsonPropertyName("message")]
    public required string Message { get; set; }
    
    [JsonPropertyName("imageUrl")]
    public required string ImageUrl { get; set; }
    
    [JsonPropertyName("rawUrl")]
    public required string RawUrl { get; set; }
    
    [JsonPropertyName("deletionUrl")]
    public required string DeletionUrl { get; set; }
}
using System.Text.Json.Serialization;

namespace EZDotNet.Core.Models.Responses;

public class PasteCreateResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    
    [JsonPropertyName("message")]
    public required string Message { get; set; }
    
    [JsonPropertyName("pasteUrl")]
    public required string PasteUrl { get; set; }
    
    [JsonPropertyName("rawUrl")]
    public required string RawUrl { get; set; }
    
    [JsonPropertyName("deletionUrl")]
    public required string DeletionUrl { get; set; }
}
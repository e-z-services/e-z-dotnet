using System.Text.Json.Serialization;

namespace EZDotNet.Core.Models.Responses;

/// <summary>
/// Represents the response received after creating a paste.
/// </summary>
public class PasteCreateResponse
{
    /// <summary>
    /// Indicates whether the paste creation was successful.
    /// </summary>
    [JsonPropertyName("success")]
    public required bool Success { get; set; }
    
    /// <summary>
    /// A message describing the result of the paste creation.
    /// </summary>
    [JsonPropertyName("message")]
    public required string Message { get; set; }
    
    /// <summary>
    /// The URL where the paste can be viewed.
    /// </summary>
    [JsonPropertyName("pasteUrl")]
    public required string PasteUrl { get; set; }
    
    /// <summary>
    /// The URL to access the raw content of the paste.
    /// </summary>
    [JsonPropertyName("rawUrl")]
    public required string RawUrl { get; set; }
    
    /// <summary>
    /// The URL that can be used to delete the paste.
    /// </summary>
    [JsonPropertyName("deletionUrl")]
    public required string DeletionUrl { get; set; }
}
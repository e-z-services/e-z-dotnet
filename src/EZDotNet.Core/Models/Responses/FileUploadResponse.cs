using System.Text.Json.Serialization;

namespace EZDotNet.Core.Models.Responses;

/// <summary>
/// Represents the response from a file upload operation.
/// </summary>
public class FileUploadResponse
{
    /// <summary>
    /// Indicates whether the upload was successful.
    /// </summary>
    [JsonPropertyName("success")]
    public required bool Success { get; set; }
    
    /// <summary>
    /// A message describing the result of the upload operation.
    /// </summary>
    [JsonPropertyName("message")]
    public required string Message { get; set; }
    
    /// <summary>
    /// The URL where the uploaded image can be viewed.
    /// </summary>
    [JsonPropertyName("imageUrl")]
    public required string ImageUrl { get; set; }
    
    /// <summary>
    /// The direct URL to the raw file content.
    /// </summary>
    [JsonPropertyName("rawUrl")]
    public required string RawUrl { get; set; }
    
    /// <summary>
    /// The URL that can be used to delete the uploaded file.
    /// </summary>
    [JsonPropertyName("deletionUrl")]
    public required string DeletionUrl { get; set; }
}
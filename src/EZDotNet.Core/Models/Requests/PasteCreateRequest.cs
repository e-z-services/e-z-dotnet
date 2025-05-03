using System.Text.Json.Serialization;
using EZDotNet.Core.Models.Enums;

namespace EZDotNet.Core.Models.Requests;

/// <summary>
/// Represents a request to create a new paste.
/// </summary>
public class PasteCreateRequest
{
    /// <summary>
    /// The title of the paste. Optional.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    
    /// <summary>
    /// A description of the paste. Optional.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    /// <summary>
    /// The content of the paste.
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }
    
    /// <summary>
    /// The programming language for syntax highlighting.
    /// </summary>
    [JsonPropertyName("language")]
    public PasteLanguage Language { get; set; }
}
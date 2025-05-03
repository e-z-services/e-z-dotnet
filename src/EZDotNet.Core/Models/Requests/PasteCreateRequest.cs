using System.Text.Json.Serialization;
using EZDotNet.Core.Models.Enums;

namespace EZDotNet.Core.Models.Requests;

public class PasteCreateRequest
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    
    [JsonPropertyName("text")]
    public required string Text { get; set; }
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("language")] 
    public PasteLanguage? Language { get; set; } = PasteLanguage.Plaintext;
}
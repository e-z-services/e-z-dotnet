using System.Text.Json.Serialization;

namespace EZDotNet.Core.Models.Requests;

public class ShortenerCreateRequest
{
    [JsonPropertyName("url")]
    public required string Url { get; set; }
}
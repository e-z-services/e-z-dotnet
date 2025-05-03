using System.Text.Json.Serialization;

namespace EZDotNet.Core.Models.Enums;

/// <summary>
/// Supported programming languages for paste syntax highlighting.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PasteLanguage
{
    [JsonPropertyName("plaintext")]
    Plaintext,
    [JsonPropertyName("bash")]
    Bash,
    [JsonPropertyName("c")]
    C,
    [JsonPropertyName("cs")]
    Cs,
    [JsonPropertyName("cpp")]
    Cpp,
    [JsonPropertyName("css")]
    Css,
    [JsonPropertyName("diff")]
    Diff,
    [JsonPropertyName("go")]
    Go,
    [JsonPropertyName("html")]
    Html,
    [JsonPropertyName("json")]
    Json,
    [JsonPropertyName("java")]
    Java,
    [JsonPropertyName("javascript")]
    JavaScript,
    [JsonPropertyName("kotlin")]
    Kotlin,
    [JsonPropertyName("less")]
    Less,
    [JsonPropertyName("lua")]
    Lua,
    [JsonPropertyName("makefile")]
    Makefile,
    [JsonPropertyName("markdown")]
    Markdown,
    [JsonPropertyName("objectivec")]
    ObjectiveC,
    [JsonPropertyName("php")]
    Php,
    [JsonPropertyName("perl")]
    Perl,
    [JsonPropertyName("python")]
    Python,
    [JsonPropertyName("pycon")]
    PyCon,
    [JsonPropertyName("r")]
    R,
    [JsonPropertyName("ruby")]
    Ruby,
    [JsonPropertyName("rust")]
    Rust,
    [JsonPropertyName("scss")]
    Scss,
    [JsonPropertyName("sql")]
    Sql,
    [JsonPropertyName("shell")]
    Shell,
    [JsonPropertyName("swift")]
    Swift,
    [JsonPropertyName("typescript")]
    TypeScript,
    [JsonPropertyName("vbnet")]
    VbNet,
    [JsonPropertyName("yaml")]
    Yaml,
    [JsonPropertyName("ini")]
    Ini
}

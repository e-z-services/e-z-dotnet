# EZDotNet (e-z-dotnet)

A .NET library for interacting with the e-z.host API service.

## Features

- File Upload
  - Upload files via file path
  - Upload files via IFormFile (ASP.NET Core)

- URL Shortening
  - Create shortened URLs

- Paste Creation
  - Create new pastes
  - Syntax highlighting support

## Installation

dotnet add package EZDotNet

## Quick Start

### ASP.NET Core DI

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add EZServices using the extension method
builder.Services.AddEZServices(options =>
{
    options.ApiKey = builder.Configuration["EZHost:ApiKey"];
    // Optionally configure timeout if needed
    // options.Timeout = TimeSpan.FromMinutes(5);
});

[ApiController]
[Route("[controller]")]
public class FileUploadController : ControllerBase
{
    private readonly IFileService _fileService;

    public FileUploadController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        // Using the built-in extension method for IFormFile
        var response = await _fileService.UploadFileFromFormFileAsync(file);

        // Do whatever you want with the response

        return Ok();
    }
}
```

### Standard Usage
```csharp
var client = new EZServicesClient(new EZServicesOptions { ApiKey = "your-api-key" });
// Upload a file 
var fileResponse = await client.Files.UploadFileFromPathAsync("path/to/file.png");
// Create short URL 
var urlResponse = await client.Shortener.CreateShortUrlAsync("https://example.com");
// Create paste 
var pasteResponse = await client.Paste.CreatePasteAsync(new PasteCreateRequest { Title = "Title!", Description = "Description!", Text = "Hello World", Language = PasteLanguage.CSharp });
```

## Requirements

- .NET 9.0+
- Valid e-z.host API key

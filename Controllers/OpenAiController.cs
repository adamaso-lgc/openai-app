using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OpenaiApp.Services;

namespace OpenaiApp.Controllers;

[ApiController]
[Route("[controller]")]
public class OpenAiController : ControllerBase
{
    private readonly IOpenAiService _openAiService;

    public OpenAiController(IOpenAiService openAiService)
    {
        _openAiService = openAiService;
    }

    [HttpPost("CompleteSentence")]
    public async Task<IActionResult> CompleteSentence(string text)
    {
        var result = await _openAiService.CompleteSentence(text);
        return Ok(result);
    }

}
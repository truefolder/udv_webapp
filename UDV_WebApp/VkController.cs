using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class VkController : ControllerBase
{
    [HttpGet("GetPosts")]
    public async Task<ActionResult<IEnumerable<string>>> GetPosts([FromQuery] long pageId)
    {
        LogManager.GetCurrentClassLogger().Trace("Запущен метод GetPosts");
        var posts = await VkService.GetPostsAsync(pageId);
        LogManager.GetCurrentClassLogger().Trace("Метод GetPosts завершил исполнение");
        return Ok(posts);
    }

    [HttpGet("CountLetters")]
    public async Task<ActionResult<Dictionary<char, int>>> CountLetters([FromQuery] long pageId)
    {
        LogManager.GetCurrentClassLogger().Trace("Вызван метод CountLetters");
        var letters = await VkService.CountLettersAsync(pageId);
        LogManager.GetCurrentClassLogger().Trace("Метод CountLetters завершил исполнение");
        return Ok(letters);
    }
}
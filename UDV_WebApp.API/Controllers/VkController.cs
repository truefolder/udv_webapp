using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Collections.Generic;
using System.Threading.Tasks;
using UDV_WebApp.Core.Abstractions;
using UDV_WebApp.Core.Models;
using UDV_WebApp.Application.Services;

namespace UDV_WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VkController : Controller
    {
        IVkService _vkService;
        IStatisticsService _statsService;
        NLog.ILogger _logger;
        IRepository<CountResult> _repository;

        public VkController(IVkService vkService, IStatisticsService statisticsService, IRepository<CountResult> repository)
        {
            _vkService = vkService;
            _statsService = statisticsService;
            _logger = LogManager.GetCurrentClassLogger();
            _repository = repository;
        }

        [HttpGet("CountLettersFromPosts")]
        public async Task<IActionResult> CountLetters(
            [FromQuery] string accessToken,
            [FromQuery] long pageId)
        {
            _logger.Trace($"Вызван API метод {nameof(CountLetters)}");
            var posts = await _vkService.GetPostsAsync(accessToken, pageId);
            var letters = _statsService.CountLetters(posts);

            _logger.Trace($"Запись результата в бд...");
            await _repository.Create(new CountResult(Guid.NewGuid(), letters));
            _logger.Trace($"Запись результата в бд окончена");

            _logger.Trace($"API метод {nameof(CountLetters)} завершил исполнение");
            return Ok(letters);
        }

        [HttpGet("GetCountedLettersFromDB")]
        public async Task<IActionResult> GetCountedLetters()
        {
            var countResults = await _repository.GetAll();

            return Ok(countResults);
        }
    }
}
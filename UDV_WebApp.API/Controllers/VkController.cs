using Microsoft.AspNetCore.Mvc;
using NLog;
using UDV_WebApp.Core.Abstractions;
using UDV_WebApp.Core.Models;
using UDV_WebApp.DataAccess.Entities;
using UDV_WebApp.API.Contracts;

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
        public async Task<ActionResult<CountLettersResponse>> CountLetters([FromQuery] CountLettersRequest request)
        {
            _logger.Debug($"API Method called: {nameof(CountLetters)}");
            var posts = await _vkService.GetPostsAsync(request.AccessToken, request.PageId, request.PostsCount);
            var letters = await _statsService.CountLetters(posts);

            _logger.Debug($"API Method {nameof(CountLetters)} call ended");
            return Ok(letters);
        }
    }
}
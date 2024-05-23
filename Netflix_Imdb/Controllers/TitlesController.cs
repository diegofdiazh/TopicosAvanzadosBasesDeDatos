using Microsoft.AspNetCore.Mvc;
using Netflix_Imdb.Application.Entity;
using Netflix_Imdb.Application.Services.Interfaces;

namespace Netflix_Imdb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TitlesController : ControllerBase
    {
        private readonly ITitleService _titleService;

        public TitlesController(ITitleService titleService)
        {
            _titleService = titleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTitles()
        {
            var (titles, count) = await _titleService.GetAllTitlesAsync();
            return Ok(new { Count = count, Titles = titles });
        }
        [HttpGet("all-by-revenue")]
        public async Task<IActionResult> GetAllTitlesByRevenue()
        {
            var (titles, count) = await _titleService.GetAllTitlesByRevenueAsync();
            return Ok(new { Count = count, Titles = titles });
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchTitles([FromQuery] List<string> genres, double? score)
        {
            var (titles, count) = await _titleService.SearchTitlesAsync(genres, score);
            return Ok(new { Count = count, Titles = titles });
        }

        [HttpGet("top-revenue-genres")]
        public async Task<IActionResult> GetTitlesByGenreAndRevenue([FromQuery] string[] genres)
        {
            var (titles, count) = await _titleService.GetTitlesByGenreAndRevenueAsync(genres);
            return Ok(new { Count = count, Titles = titles });
        }


    }
}

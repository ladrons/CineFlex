using AutoMapper;
using CineFlex.Application.Interfaces.Managers;
using CineFlex.Application.ViewModels;
using CineFlex.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.WebUI.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/[controller]")]
    public class GenreController : Controller
    {
        private readonly ILogger<GenreController> _logger;
        private readonly IMapper _mapper;

        IGenreManager _genreMan;

        public GenreController(IMapper mapper, ILogger<GenreController> logger, IGenreManager genreMan, IMovieGenreManager movieGenreMan)
        {
            _genreMan = genreMan;
            _logger = logger;
            _mapper = mapper;           
        }

        //----//

        [Route("AddGenre")]
        public IActionResult AddGenre() => View();

        [HttpPost]
        [Route("AddGenre")]
        public IActionResult AddGenre(GenreVM genre)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                if (_genreMan.CheckGenreNameExist(genre.Name))
                {
                    ModelState.AddModelError("Name", $"{genre.Name} isimli tür veritabanında kayıtlıdır.");
                    return View(genre);
                }

                Genre newGenre = _mapper.Map<Genre>(genre);

                _genreMan.Add(newGenre);
                _genreMan.SaveChanges();

                return RedirectToAction("Dashboard", "Home", new { area = "Management" });
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"## Bir hata meydaha geldi: {ex.Message} ##");
                return RedirectToAction("Error", "Home");
            }
        }

        //----//
    }
}
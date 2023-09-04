using AutoMapper;
using CineFlex.Application.Interfaces.Managers;
using CineFlex.Application.Interfaces.Services;
using CineFlex.Domain.Models;
using CineFlex.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.WebUI.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/[controller]")]
    public class SeanceController : Controller
    {
        ISeanceManager _seanceMan; ITheaterManager _theaterMan; IMovieManager _movieMan; IMovieFormatManager _movieFormatMan;

        public SeanceController(ISeanceManager seanceMan, ITheaterManager theaterMan, IMovieManager movieMan, IMovieFormatManager movieFormatMan)
        {
            _seanceMan = seanceMan;
            _theaterMan = theaterMan;
            _movieMan = movieMan;
            _movieFormatMan = movieFormatMan;

        }

        //----------//

        [Route("SeanceList")]
        public IActionResult SeanceList()
        {
            return View();
        }

        //-----//

        [Route("CreateSeance")]
        public IActionResult CreateSeance(int id) => View(PrepareViewModelForCreateSeance(id));

        [HttpPost]
        [Route("CreateSeance")]
        public IActionResult CreateSeance(SeanceVM seance)
        {
            if (!ModelState.IsValid)
                return View(PrepareViewModelForCreateSeance(seance.MovieId));

            Theater foundTheater = _theaterMan.Find(seance.TheaterId);
            Movie foundMovie = _movieMan.Find(seance.MovieId);

            if (_seanceMan.CreateAndSaveSeances(foundTheater, foundMovie, seance.StartDate, seance.EndDate, seance.SeanceTimeList))
                return View(); //ToDo: Seanslar oluştuktan sonra ilgili film ve salon için aktif seansların gözüktüğü bir listeye yönlendir.

            else return RedirectToAction("Error", "Home", new { area = "Management" });
        }

        //----------//

        #region HelperMethods
        private SeanceVM PrepareViewModelForCreateSeance(int movieId)
        {
            Movie selectedMovie = _movieMan.Find(movieId);
            List<Format> selectedMovieFormats = _movieFormatMan.GetMovieFormats(movieId);

            var activeTheaters = _theaterMan
                .Where(theater => theater.Status != Domain.Enums.DataStatus.Deleted && theater.IsOpen == true)
                .ToList();

            var theatersWithMatchingFormat = activeTheaters
            .Where(theater => selectedMovieFormats.Any(format => format.Name == theater.ScreenType))
            .ToList();

            SeanceVM svm = new SeanceVM
            {
                SelectedMovie = selectedMovie,
                ActiveTheaters = theatersWithMatchingFormat
            };
            return svm;
        }
        #endregion
    }
}


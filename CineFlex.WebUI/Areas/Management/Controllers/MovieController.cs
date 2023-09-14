using AutoMapper;
using CineFlex.Application.Interfaces.Managers;
using CineFlex.Application.ViewModels;
using CineFlex.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Transactions;
using CineFlex.Infrastructure.Services;
using CineFlex.Application.Interfaces.Services;

namespace CineFlex.WebUI.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/[controller]")]
    public class MovieController : Controller
    {
        private readonly IMapper _mapper;


        IMovieManager _movieMan; IGenreManager _genreMan; IFormatManager _formatMan; IMovieFormatManager _movieFormatMan; IMovieGenreManager _movieGenreMan;

        public MovieController(IMapper mapper, IMovieManager movieMan, IGenreManager genreMan, IFormatManager formatMan, IMovieFormatManager movieFormatMan, IMovieGenreManager movieGenreMan)
        {
            _mapper = mapper;

            _movieMan = movieMan;
            _genreMan = genreMan;
            _formatMan = formatMan;

            _movieFormatMan = movieFormatMan;
            _movieGenreMan = movieGenreMan;
        }

        //----------//

        [Route("MovieList")]
        public IActionResult MovieList()
        {
            MovieVM mvm = new MovieVM
            {
                ActiveMovies = _movieMan.GetActives(),
            };
            return View(mvm);
        }

        //-----//

        [Route("AddMovie")]
        public IActionResult AddMovie() => View(PrepareViewModel());

        [HttpPost]
        [Route("AddMovie")]
        public IActionResult AddMovie(MovieVM movie)
        {
            if (!ModelState.IsValid) return View(PrepareViewModel());

            try
            {
                Movie newMovie = _mapper.Map<Movie>(movie);
                using (var transaction = new TransactionScope())
                {
                    _movieMan.AddAndSaveMovie(newMovie);

                    _movieGenreMan.AssignGenresToMovie(movie.SelectedGenreIds, newMovie, _genreMan);
                    _movieFormatMan.AssignFormatsToMovie(movie.SelectedFormatIds, newMovie, _formatMan);

                    transaction.Complete();
                }
                return RedirectToAction("Dashboard", "Home", new { area = "Management" });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error", "Home", new { area = "Management" });
            }
        }

        //-----//

        #region HelperMethods
        private MovieVM PrepareViewModel() //Todo: Metodun adı daha açıklayıcı olmalı.
        {
            MovieVM mvm = new MovieVM
            {
                ActiveGenres = _genreMan.GetActives(),
                ActiveFormats = _formatMan.GetActives()
            };
            return mvm;
        }
        #endregion
    }
}
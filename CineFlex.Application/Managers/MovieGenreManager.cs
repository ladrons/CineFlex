using CineFlex.Application.Interfaces.Managers;
using CineFlex.Domain.Interfaces.Repositories;
using CineFlex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Managers
{
    public class MovieGenreManager : BaseManager<MovieGenre>, IMovieGenreManager
    {
        IMovieGenreRepository _movieGenreRep;

        public MovieGenreManager(IMovieGenreRepository movieGenreRep) : base(movieGenreRep)
        {
            _movieGenreRep = movieGenreRep;
        }

        //----------//

        public void AssignGenresToMovie(List<int> genreIds, Movie newMovie, IGenreManager genreMan)
        {
            List<MovieGenre> newMovieGenres = genreIds.Select(genreId => new MovieGenre
            {
                Movie = newMovie,
                Genre = genreMan.Find(genreId)
            }).ToList();

            _movieGenreRep.AddRange(newMovieGenres);
            _movieGenreRep.SaveChanges();
        }
    }
}
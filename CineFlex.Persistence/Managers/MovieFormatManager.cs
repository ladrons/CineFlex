using CineFlex.Application.Interfaces.Managers;
using CineFlex.Application.Interfaces.Repositories;
using CineFlex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Managers
{
    public class MovieFormatManager : BaseManager<MovieFormat>, IMovieFormatManager
    {
        IMovieFormatRepository _movieFormatRep;

        public MovieFormatManager(IMovieFormatRepository movieFormatRep) : base(movieFormatRep)
        {
            _movieFormatRep = movieFormatRep;
        }

        //------------//

        public void AssignFormatsToMovie(List<int> formatIds, Movie newMovie, IFormatManager formatMan)
        {
            List<MovieFormat> newMovieFormats = formatIds.Select(formatId => new MovieFormat
            {
                Movie = newMovie,
                Format = formatMan.Find(formatId)
            }).ToList();

            _movieFormatRep.AddRange(newMovieFormats);
            _movieFormatRep.SaveChanges();
        }


        public List<Format> GetMovieFormats(int movieId)
        {
            List<Format> movieFormats = _movieFormatRep.Where(x => x.MovieId == movieId).Select(x => x.Format).ToList();
            return movieFormats;
        }
    }
}
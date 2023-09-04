using CineFlex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Interfaces.Managers
{
    public interface IMovieFormatManager : IManager<MovieFormat>
    {
        void AssignFormatsToMovie(List<int> formatIds, Movie newMovie, IFormatManager formatMan);
        List<Format> GetMovieFormats(int movieId);
    }
}

using CineFlex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Interfaces.Managers
{
    public interface IMovieGenreManager : IManager<MovieGenre>
    {
        void AssignGenresToMovie(List<int> genreIds, Movie newMovie, IGenreManager genreMan);
    }
}

using CineFlex.Application.Interfaces.Managers;
using CineFlex.Application.Interfaces.Repositories;
using CineFlex.Domain.Models;
using CineFlex.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Managers
{
    public class MovieManager : BaseManager<Movie>, IMovieManager
    {
        IMovieRepository _movieRep;

        public MovieManager(IMovieRepository movieRep) : base(movieRep)
        {
            _movieRep = movieRep;
        }

        //------------//

        public void AddAndSaveMovie(Movie newMovie)
        {
            if(CheckMovieNameExist(newMovie.Title))
                throw new Exception($"{newMovie.Title} isimli film zaten kayıtlıdır.");
            else if(CheckDateMovie(newMovie.ReleaseDate))
                throw new Exception("Vizyon tarihi geçmiş tarih olamaz.");

            _movieRep.Add(newMovie);
            _movieRep.SaveChanges();
        }

        private bool CheckMovieNameExist(string movieName)
        {
            if (_movieRep.Any(x => x.Title.ToLower() == movieName.ToLower())) return true; 
            return false;
        }
        private bool CheckDateMovie(DateTime releaseDate)
        {
            if (releaseDate < DateTime.Now) return true;
            else return false;
        }
    }
}
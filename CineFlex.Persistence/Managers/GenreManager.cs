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
    public class GenreManager : BaseManager<Genre>, IGenreManager
    {
        IGenreRepository _genreRep;

        public GenreManager(IGenreRepository genreRep) : base(genreRep)
        {
            _genreRep = genreRep;
        }

        public bool CheckGenreNameExist(string genreNamwe)
        {
            if (_genreRep.Any(x => x.Name.ToLower() == genreNamwe.ToLower())) return true;
            else return false;
        }
    }
}
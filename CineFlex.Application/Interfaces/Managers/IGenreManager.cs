using CineFlex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Interfaces.Managers
{
    public interface IGenreManager : IManager<Genre>
    {
        bool CheckGenreNameExist(string genreNamwe);
    }
}

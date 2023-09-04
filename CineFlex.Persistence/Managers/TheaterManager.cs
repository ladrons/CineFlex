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
    public class TheaterManager : BaseManager<Theater>, ITheaterManager
    {
        ITheaterRepository _theaterRep;

        public TheaterManager(ITheaterRepository theaterRep) : base(theaterRep)
        {
            _theaterRep = theaterRep;
        }

        //----------//

        public bool IsTheaterOpen(Theater theater)
        {
            if (theater.IsOpen)
                return true; return false;
        }
    }
}
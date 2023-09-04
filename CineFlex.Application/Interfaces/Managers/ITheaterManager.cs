using CineFlex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Interfaces.Managers
{
    public interface ITheaterManager : IManager<Theater>
    {
        bool IsTheaterOpen(Theater theater);
    }
}

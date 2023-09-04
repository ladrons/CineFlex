using CineFlex.Application.Interfaces.Services;
using CineFlex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Interfaces.Managers
{
    public interface ISeanceManager : IManager<Seance>
    {
        bool CreateAndSaveSeances(Theater theater, Movie movie, DateTime startDate, DateTime endDate, List<DateTime> seanceTimes);
        bool CheckSeanceTime(Seance seance, DateTime currentTime);
        List<DateTime> GetSelectedMovieSeanceDates(Movie movie, DateTime currentDateTime);
        Seance GetSeanceByAttributes(int movieId, string seanceDate, string seanceTime);
    }
}
using CineFlex.Application.Interfaces.Managers;
using CineFlex.Application.Interfaces.Repositories;
using CineFlex.Application.Interfaces.Services;
using CineFlex.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Managers
{
    public class SeanceManager : BaseManager<Seance>, ISeanceManager
    {
        private readonly IErrorService _errorService;

        ISeanceRepository _seanceRep;

        public SeanceManager(ISeanceRepository seanceRep, IErrorService errorService) : base(seanceRep)
        {
            _seanceRep = seanceRep;
            _errorService = errorService;
        }

        //------------//

        public bool CreateAndSaveSeances(Theater theater, Movie movie, DateTime startDate, DateTime endDate, List<DateTime> seanceTimes)
        {
            try
            {
                List<Seance> newSeances = GenerateSeances(theater, movie, startDate, endDate, seanceTimes);

                _seanceRep.AddRange(newSeances);
                _seanceRep.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _errorService.LogException(ex);
                return false;
            }
        }
        public List<DateTime> GetSelectedMovieSeanceDates(Movie movie, DateTime currentDateTime)
        {
            List<DateTime> seancesDate = new List<DateTime>();

            foreach (var seance in movie.Seances.Where(x => x.Status != Domain.Enums.DataStatus.Deleted).OrderBy(x => x.SeanceDate))
            {
                if (CheckSeanceDate(seance, currentDateTime))
                {
                    if (seancesDate.IsNullOrEmpty()) seancesDate.Add(seance.SeanceDate);
                    else
                    {
                        int lastIndex = seancesDate.Count - 1;
                        if (seancesDate[lastIndex] != seance.SeanceDate)
                        {
                            seancesDate.Add(seance.SeanceDate);
                        }
                    }
                }
            }
            return seancesDate;
        }
        public bool CheckSeanceTime(Seance seance, DateTime currentTime)
        {
            if (seance.SeanceDate.Date == currentTime.Date)
            {
                return seance.SeanceTime.AddMinutes(-30) > currentTime ? true : false;
            }

            return true;
        }
        public Seance GetSeanceByAttributes(int movieId, string seanceDate, string seanceTime)
        {
            DateTime date = Convert.ToDateTime(seanceDate);
            TimeSpan time = (Convert.ToDateTime(seanceTime)).TimeOfDay;

            Seance foundSeance = _seanceRep.FirstOrDefault(x =>
                x.SeanceDate == date.Date &&
                x.SeanceTime.TimeOfDay == time &&
                x.MovieId == movieId);

            return foundSeance;
        }

        //-----//

        private bool CheckSeanceDate(Seance seance, DateTime currentDateTime)
        {
            if (seance.SeanceDate > currentDateTime.Date)
            {
                return true;
            }
            else if (seance.SeanceDate == currentDateTime.Date)
            {
                return CheckSeanceTime(seance, currentDateTime);
            }

            return false;
        }
        private List<Seance> GenerateSeances(Theater theater, Movie movie, DateTime startDate, DateTime endDate, List<DateTime> seanceTimes)
        {
            if (IsValidSeanceDate(movie.ReleaseDate, startDate, endDate))
            {
                List<Seance> seances = new List<Seance>();

                List<DateTime> seanceDates = GenerateDateRange(startDate, endDate);
                foreach (var seanceDate in seanceDates)
                {
                    foreach (var seanceTime in seanceTimes)
                    {
                        Seance newSeance = new Seance
                        {
                            Theater = theater,
                            Movie = movie,

                            SeanceDate = seanceDate,
                            SeanceTime = seanceTime
                        };
                        seances.Add(newSeance);
                    }
                }
                return seances;
            }
            else
            {
                //False dönerse, Seans başlangıç ya da bitiş tarihi hatalıdır.
                throw new Exception($"Hata: {movie.Title} filmi için geçerli seans tarihleri sağlanmadı.");
            }
        }
        private bool IsValidSeanceDate(DateTime releaseDate, DateTime startDate, DateTime endDate)
        {
            return startDate >= releaseDate && startDate >= DateTime.Now.Date && endDate > startDate;
        }
        private List<DateTime> GenerateDateRange(DateTime startDate, DateTime endDate)
        {
            List<DateTime> dateRange = new List<DateTime>();
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                dateRange.Add(date);
            }
            return dateRange;
        }
    }
}
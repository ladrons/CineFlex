using CineFlex.Domain.Models;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CineFlex.WebUI.ViewModels
{
    public class SeanceVM
    {
        [Required(ErrorMessage = "Başlangıç tarihi boş bırakılamaz.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi boş bırakılamaz.")]
        public DateTime EndDate { get; set; }

        public List<DateTime> SeanceTimeList { get; set; }

        public Movie SelectedMovie { get; set; }

        public int MovieId { get; set; }
        public int TheaterId { get; set; }

        public List<Theater> ActiveTheaters { get; set; }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CineFlex.WebUI.ViewModels
{
    public class TheaterVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Salon adı boş bırakılamaz.")]
        [Remote(action: "HasTheaterName", controller: "Theater")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Salon kapasitesi boş bırakılamaz.")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Salonun ekran türü belirtilmelidir.")]
        public string ScreenType { get; set; } //2D, 3D, IMAX
        public bool IsOpen { get; set; }
    }
}
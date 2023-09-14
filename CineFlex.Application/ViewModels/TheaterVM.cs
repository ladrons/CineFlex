using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CineFlex.Application.ViewModels
{
    public class TheaterVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Salon adı boş bırakılamaz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Salon kapasitesi boş bırakılamaz.")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Salonun ekran türü belirtilmelidir.")]
        public string ScreenType { get; set; }
        public bool IsOpen { get; set; }
    }
}
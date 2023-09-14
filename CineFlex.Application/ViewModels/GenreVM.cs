using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CineFlex.Application.ViewModels
{
    public class GenreVM
    {
        [Required(ErrorMessage = "Tür ismi boş bırakılamaz.")]
        public string Name { get; set; }
    }
}

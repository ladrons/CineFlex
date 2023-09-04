using System.ComponentModel.DataAnnotations;

namespace CineFlex.WebUI.ViewModels
{
    public class GenreVM
    {
        [Required(ErrorMessage = "Tür ismi boş bırakılamaz.")]
        public string Name { get; set; }
    }
}

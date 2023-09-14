using System.ComponentModel.DataAnnotations;

# nullable disable

namespace CineFlex.Application.ViewModels
{
    public class FormatVM
    {
        [Required(ErrorMessage = "Format adı boş bırakılamaz.")]
        public string Name { get; set; }
    }
}

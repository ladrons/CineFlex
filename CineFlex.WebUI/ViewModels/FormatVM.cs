using System.ComponentModel.DataAnnotations;

namespace CineFlex.WebUI.ViewModels
{
    public class FormatVM
    {
        [Required(ErrorMessage = "Format adı boş bırakılamaz.")]
        public string Name { get; set; }
    }
}

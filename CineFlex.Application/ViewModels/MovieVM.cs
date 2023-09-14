using CineFlex.Application.Attributes;
using CineFlex.Domain.Models;
using System.ComponentModel.DataAnnotations;

# nullable disable

namespace CineFlex.Application.ViewModels
{
    //APPLICATION Kısmı

    public class MovieVM
    {
        //Models Properties
        [Required(ErrorMessage = "Film adı boş bırakılamaz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Yönetmen kısmı boş bırakılamaz.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Film süresi boş bırakılamaz.")]
        public int DurationInMunite { get; set; }

        [Required(ErrorMessage = "Vizyon tarihi boş bırakılamaz.")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Film konusu boş bırakılamaz.")]
        public string Description { get; set; }

        //public string? PosterUrl { get; set; }

        //---------------//

        //Other Properties
        [NonEmptyList(ErrorMessage = "En az bir adet tür seçmelisiniz.")]
        public List<int> SelectedGenreIds { get; set; }

        [NonEmptyList(ErrorMessage = "En az bir adet format seçmelisiniz.")]
        public List<int> SelectedFormatIds { get; set; }


        public IQueryable<Movie> ActiveMovies { get; set; }
        public IQueryable<Genre> ActiveGenres { get; set; }
        public IQueryable<Format> ActiveFormats { get; set; }
    }
}
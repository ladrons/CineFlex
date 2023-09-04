using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public int DurationInMunite { get; set; }
        public DateTime ReleaseDate { get; set; }        
        public string Description { get; set; }
        public string? PosterUrl { get; set; }


        public Movie()
        {
            
        }

        //Relational Properties
        public virtual ICollection<Seance>? Seances { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
        public virtual ICollection<MovieFormat> MovieFormats { get; set; }
    }
}
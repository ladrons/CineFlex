using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain.Models
{
    public class MovieGenre : BaseEntity
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }


        public MovieGenre()
        {
            
        }

        //Relational Properties
        public virtual Movie Movie { get; set; }
        public virtual Genre Genre { get; set; }
    }
}

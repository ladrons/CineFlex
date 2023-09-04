using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain.Models
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }


        public Genre()
        {
            
        }

        //Relational Properties
        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}

using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain.Models
{
    public class MovieFormat : BaseEntity
    {
        public int MovieId { get; set; }
        public int FormatId { get; set; }


        public MovieFormat()
        {
            
        }

        //Relational Properties
        public virtual Movie Movie { get; set; }
        public virtual Format Format { get; set; }  
    }
}

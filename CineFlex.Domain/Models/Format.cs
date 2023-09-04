using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain.Models
{
    public class Format : BaseEntity
    {
        public string Name { get; set; }


        public Format()
        {
            
        }

        //Relational Properties
        public virtual ICollection<MovieFormat> MovieFormats { get; set; }
    }
}

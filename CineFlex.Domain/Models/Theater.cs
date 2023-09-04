using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain.Models
{
    public class Theater : BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string ScreenType { get; set; } //2D, 3D, IMAX
        public bool IsOpen { get; set; }

        public Theater()
        {
            IsOpen = false;
        }

        //Relational Properties
        public virtual ICollection<Seance>? Seances { get; set; }
    }
}
using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain.Models
{
    public class Reservation : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime SeanceDate { get; set; }
        public string SeanceTime { get; set; }
        public string SeatInfo { get; set; }

        public int? CustomerId { get; set; }
        public int SeanceId { get; set; }


        public Reservation()
        {
            
        }

        //Relational Properties
        public virtual Customer? Customer { get; set; }
        public virtual Seance Seance { get; set; }
    }
}

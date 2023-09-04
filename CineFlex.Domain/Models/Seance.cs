using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain.Models
{
    public class Seance : BaseEntity
    {
        public DateTime SeanceDate { get; set; }
        public DateTime SeanceTime { get; set; }
        public bool IsActive { get; set; }

        public Seance()
        {
            IsActive = false;
        }

        public int TheaterId { get; set; }
        public int MovieId { get; set; }


        //Relational Properties
        public virtual Theater Theater { get; set; }
        public virtual Movie Movie { get; set; }

        public virtual ICollection<SoldTicket>? SoldTickets { get; set; }
        public virtual ICollection<Reservation>? Reservations { get; set; }
    }
}
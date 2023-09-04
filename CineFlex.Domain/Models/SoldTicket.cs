using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain.Models
{
    public class SoldTicket : BaseEntity
    {
        public string MovieTitle { get; set; }
        public string TheaterName { get; set; }
        public DateTime SeanceStartDate { get; set; }
        public DateTime SeanceStartTime { get; set; }

        public string SeatInfo { get; set; }
        public int SalesCode { get; set; }

        public int? CustomerId { get; set; }
        public int TicketId { get; set; }
        public int SeanceId { get; set; }


        public SoldTicket()
        {
            
        }

        //Relational Properties
        public virtual Customer? Customer { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual Seance Seance { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.DTOs
{
    public class SubTicketInfoDTO
    {
        //Ticket Properties
        public string TicketName { get; set; }
        public decimal TicketPrice { get; set; }

        public int TicketId { get; set; }

        //Seat Properties
        public string SeatName { get; set; }
    }
}

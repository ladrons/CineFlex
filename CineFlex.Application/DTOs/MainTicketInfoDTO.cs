using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

# nullable disable

namespace CineFlex.Application.DTOs
{
    public class MainTicketInfoDTO
    {
        public MainTicketInfoDTO()
        {
            SubTicketInfos = new List<SubTicketInfoDTO>();
            TicketNames = new List<string>();
        }

        //Movie Properties
        public string MovieTitle { get; set; }
        public int DurationInMunite { get; set; }

        // Seance Properties
        public DateTime SeanceStartDate { get; set; }
        public DateTime SeanceStartTime { get; set; }

        //Theater Properties
        public string TheaterName { get; set; }
        public int TheaterCapacity { get; set; }
        public string ScreenType { get; set; }

        //Common Properties
        public decimal TotalPrice { get; set; }
        public int TicketQuantity { get; set; }

        //Ids Properties
        public int MovieId { get; set; }
        public int TheaterId { get; set; }
        public int SeanceId { get; set; }        

        //List Properties
        public List<string> TicketNames { get; set; }
        public List<SubTicketInfoDTO> SubTicketInfos { get; set; } //TODO: İsmi 'SubTicketsInfo' olarak değiştir.
    }
}
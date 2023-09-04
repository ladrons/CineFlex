using CineFlex.Application.DTOs;
using CineFlex.Domain.Models;

namespace CineFlex.WebUI.ViewModels
{
    public class TicketingVM
    {
        //Customer / Guest Properties
        public string CustomerFullname { get; set; }
        public string GuestFullname { get; set; }
        public string Email { get; set; }

        //Seance Properties
        public string SeanceDate { get; set; }
        public string SeanceTime { get; set; }

        //Theater Properties
        public int TheaterCapacity { get; set; }

        //Ticket Properties
        public int TicketQuantity { get; set; }

        //Id Properties
        public int MovieId { get; set; }

        //Other Properties
        public PaymentDTO PaymentDTO { get; set; }

        public ICollection<string> SoldSeats { get; set; }
        public ICollection<DateTime> MovieSeancesDate { get; set; }

        public IQueryable<Ticket> ActiveTickets { get; set; }
    }
}
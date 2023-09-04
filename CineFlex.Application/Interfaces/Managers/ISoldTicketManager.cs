using CineFlex.Application.DTOs;
using CineFlex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Interfaces.Managers
{
    public interface ISoldTicketManager : IManager<SoldTicket>
    {
        
        MainTicketInfoDTO CreateTempTicket(Movie movie, Theater theater, Seance seance);
        MainTicketInfoDTO ProcessSelectedTickets(Dictionary<int, int> ticketQuantities, MainTicketInfoDTO tempTicket, ITicketManager ticketMan);
        Task<bool> CreateSoldTicket(MainTicketInfoDTO tempTicket, Customer customer = null);
    }
}

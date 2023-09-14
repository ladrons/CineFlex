using CineFlex.Application.Interfaces.Managers;
using CineFlex.Domain.Interfaces.Repositories;
using CineFlex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Managers
{
    public class TicketManager : BaseManager<Ticket> , ITicketManager
    {
        ITicketRepository _ticketRep;

        public TicketManager(ITicketRepository ticketRep) : base(ticketRep)
        {
            _ticketRep = ticketRep;
        }
    }
}

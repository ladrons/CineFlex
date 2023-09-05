using CineFlex.Application.DTOs;
using CineFlex.Application.Interfaces.Managers;
using CineFlex.Application.Interfaces.Repositories;
using CineFlex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Managers
{
    public class SoldTicketManager : BaseManager<SoldTicket>, ISoldTicketManager
    {
        ISoldTicketRepository _soldTicketRep;

        public SoldTicketManager(ISoldTicketRepository soldTicketRep) : base(soldTicketRep)
        {
            _soldTicketRep = soldTicketRep;
        }

        //-----//-----//

        public MainTicketInfoDTO CreateTempTicket(Movie movie, Theater theater, Seance seance)
        {
            return new MainTicketInfoDTO
            {
                MovieTitle = movie.Title,
                DurationInMunite = movie.DurationInMunite,

                SeanceStartDate = seance.SeanceDate,
                SeanceStartTime = seance.SeanceTime,

                TheaterName = theater.Name,
                TheaterCapacity = theater.Capacity,
                ScreenType = theater.ScreenType,

                TotalPrice = 0,
                TicketQuantity = 0,

                MovieId = movie.Id,
                TheaterId = theater.Id,
                SeanceId = seance.Id,
            };
        }
        public MainTicketInfoDTO ProcessSelectedTickets(Dictionary<int, int> ticketQuantities, MainTicketInfoDTO tempTicket, ITicketManager ticketMan)
        {
            foreach (KeyValuePair<int, int> pair in ticketQuantities)
            {
                Ticket foundTicket = ticketMan.Find(pair.Key);
                tempTicket.TicketNames.Add(foundTicket.Name);

                for (int i = 0; i < pair.Value; i++)
                {
                    tempTicket.TotalPrice += foundTicket.Price;
                    tempTicket.TicketQuantity++;

                    AddSubTicketToTempTicket(tempTicket, foundTicket);
                }
            }
            return tempTicket;
        }

        //-----//

        public async Task<bool> CreateSoldTicket(MainTicketInfoDTO tempTicket, Customer customer = null)
        {
            try
            {
                foreach (SubTicketInfoDTO item in tempTicket.SubTicketsInfo)
                {
                    SoldTicket newSoldTicket = new SoldTicket
                    {
                        MovieTitle = tempTicket.MovieTitle,
                        TheaterName = tempTicket.TheaterName,

                        SeanceStartDate = tempTicket.SeanceStartDate,
                        SeanceStartTime = tempTicket.SeanceStartTime,

                        SeatInfo = item.SeatName,

                        SeanceId = tempTicket.SeanceId,
                        TicketId = item.TicketId,

                        CustomerId = customer != null ? customer.Id : null
                    };
                    await _soldTicketRep.AddAsync(newSoldTicket);
                }
                await _soldTicketRep.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //-----//-----//

        private void AddSubTicketToTempTicket(MainTicketInfoDTO tempTicket, Ticket foundTicket)
        {
            SubTicketInfoDTO subTicket = new SubTicketInfoDTO
            {
                TicketName = foundTicket.Name,
                TicketPrice = foundTicket.Price,

                TicketId = foundTicket.Id
            };

            tempTicket.SubTicketsInfo.Add(subTicket);
        }
    }
}
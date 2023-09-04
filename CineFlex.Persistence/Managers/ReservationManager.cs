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
    public class ReservationManager : BaseManager<Reservation>, IReservationManager
    {
        IReservationRepository _reservationRep;

        public ReservationManager(IReservationRepository reservationRep) : base(reservationRep)
        {
            _reservationRep = reservationRep;
        }
    }
}
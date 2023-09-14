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
    public class ReservationManager : BaseManager<Reservation>, IReservationManager
    {
        IReservationRepository _reservationRep;

        public ReservationManager(IReservationRepository reservationRep) : base(reservationRep)
        {
            _reservationRep = reservationRep;
        }
    }
}
using CineFlex.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Interfaces.Context
{
    public interface ICineFlexContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieFormat> MovieFormats { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<SoldTicket> SoldTickets { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
using CineFlex.Application.Interfaces.Context;
using CineFlex.Domain.Models;
using CineFlex.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Context
{
    public class CineFlexDbContext : DbContext, ICineFlexContext
    {
        public CineFlexDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieFormatConfiguration());
        }

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
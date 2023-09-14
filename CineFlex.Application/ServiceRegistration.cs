using CineFlex.Application.Interfaces.Managers;
using CineFlex.Application.Managers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IFormatManager, FormatManager>();
            services.AddScoped<IGenreManager, GenreManager>();
            services.AddScoped<IMovieFormatManager, MovieFormatManager>();
            services.AddScoped<IMovieGenreManager, MovieGenreManager>();
            services.AddScoped<IMovieManager, MovieManager>();
            services.AddScoped<IReservationManager, ReservationManager>();
            services.AddScoped<ISeanceManager, SeanceManager>();
            services.AddScoped<ISoldTicketManager, SoldTicketManager>();
            services.AddScoped<ITheaterManager, TheaterManager>();
            services.AddScoped<ITicketManager, TicketManager>();
        }
    }
}
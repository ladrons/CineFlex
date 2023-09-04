using CineFlex.Application.Interfaces.Managers;
using CineFlex.Application.Interfaces.Repositories;
using CineFlex.Persistence.Context;
using CineFlex.Persistence.Managers;
using CineFlex.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddDbContextPool<CineFlexDbContext>(options =>
            options.UseSqlServer(configuration?.GetConnectionString("MyConnection")).UseLazyLoadingProxies());


            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerManager, CustomerManager>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();

            services.AddScoped<IFormatRepository, FormatRepository>();
            services.AddScoped<IFormatManager, FormatManager>();

            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IGenreManager, GenreManager>();

            services.AddScoped<IMovieFormatRepository, MovieFormatRepository>();
            services.AddScoped<IMovieFormatManager, MovieFormatManager>();

            services.AddScoped<IMovieGenreRepository, MovieGenreRepository>();
            services.AddScoped<IMovieGenreManager, MovieGenreManager>();

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieManager, MovieManager>();

            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IReservationManager, ReservationManager>();

            services.AddScoped<ISeanceRepository, SeanceRepository>();
            services.AddScoped<ISeanceManager, SeanceManager>();

            services.AddScoped<ISoldTicketRepository, SoldTicketRepository>();
            services.AddScoped<ISoldTicketManager, SoldTicketManager>();

            services.AddScoped<ITheaterRepository, TheaterRepository>();
            services.AddScoped<ITheaterManager, TheaterManager>();

            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketManager, TicketManager>();
        }
    }
}

/*
 `UseLazyLoadingProxies()` metodu, Entity Framework Core ile ilişkisel veritabanı modelleri oluştururken tembel yükleme (lazy loading) özelliğini etkinleştiren bir yapılandırma seçeneğidir.
 
Tembel Yükleme: veritabanı tabloları arasındaki ilişkileri modellediğinizde, ilişkili verilerin sadece ihtiyaç duyulduğu zaman yüklenmesini sağlayan bir yöntemdir.
 */
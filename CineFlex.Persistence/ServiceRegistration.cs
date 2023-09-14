using CineFlex.Application.Interfaces.Managers;
using CineFlex.Domain.Interfaces.Repositories;
using CineFlex.Persistence.Context;
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
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IFormatRepository, FormatRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IMovieFormatRepository, MovieFormatRepository>();
            services.AddScoped<IMovieGenreRepository, MovieGenreRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<ISeanceRepository, SeanceRepository>();
            services.AddScoped<ISoldTicketRepository, SoldTicketRepository>();
            services.AddScoped<ITheaterRepository, TheaterRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
        }
    }
}

/*
 `UseLazyLoadingProxies()` metodu, Entity Framework Core ile ilişkisel veritabanı modelleri oluştururken tembel yükleme (lazy loading) özelliğini etkinleştiren bir yapılandırma seçeneğidir.
 
Tembel Yükleme: veritabanı tabloları arasındaki ilişkileri modellediğinizde, ilişkili verilerin sadece ihtiyaç duyulduğu zaman yüklenmesini sağlayan bir yöntemdir.
 */
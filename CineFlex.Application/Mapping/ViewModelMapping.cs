using AutoMapper;
using CineFlex.Application.ViewModels;
using CineFlex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Mapping
{
    public class ViewModelMapping : Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Movie, MovieVM>().ReverseMap();
            CreateMap<Genre, GenreVM>().ReverseMap();
            CreateMap<Format, FormatVM>().ReverseMap();

            CreateMap<Theater, TheaterVM>().ReverseMap();
            CreateMap<Ticket, TicketVM>().ReverseMap();
        }
    }
}

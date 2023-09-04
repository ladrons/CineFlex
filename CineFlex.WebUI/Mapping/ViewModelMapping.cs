using AutoMapper;
using CineFlex.WebUI.ViewModels;
using CineFlex.Domain.Models;

namespace CineFlex.WebUI.Mapping
{
    public class ViewModelMapping : Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Genre, GenreVM>().ReverseMap();
            CreateMap<Format, FormatVM>().ReverseMap();
            CreateMap<Movie, MovieVM>().ReverseMap();
            CreateMap<Theater, TheaterVM>().ReverseMap();
            CreateMap<Ticket, TicketVM>().ReverseMap();
        }
    }
}
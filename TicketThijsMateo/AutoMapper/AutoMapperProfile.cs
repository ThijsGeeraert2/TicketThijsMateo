using AutoMapper;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {

            CreateMap<Club, ClubVM>();

            CreateMap<Wedstrijd, WedstrijdVM>()
                .ForMember(dest => dest.Stadium, opts => opts.MapFrom(src => src.Stadium.Name))
                .ForMember(dest => dest.ThuisPloeg, opts => opts.MapFrom(src => src.ThuisPloeg.Naam));


        }
    }
}

using AutoMapper;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {

            CreateMap<Club, ClubVM>();
            CreateMap<ClubVM, Club>();

        }
    }
}

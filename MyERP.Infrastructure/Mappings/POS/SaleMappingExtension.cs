using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.POS
{
    public class SaleMappingExtension : Profile
    {
        public SaleMappingExtension()
        {
            CreateMap<Sale, SaleDomain>()
                .ForMember(
                    dest => dest.Status,
                    opt => opt.Ignore());

            CreateMap<SaleDomain, Sale>()
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status));
        }
    }
}

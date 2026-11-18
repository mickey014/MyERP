using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.CRM
{
    public class FollowUpMappingExtension : Profile
    {
        public FollowUpMappingExtension()
        {
            CreateMap<FollowUp, FollowUpDomain>()
                .ForMember(
                    dest => dest.IsCompleted,
                    opt => opt.Ignore());

            CreateMap<FollowUpDomain, FollowUp>()
                .ForMember(
                    dest => dest.IsCompleted,
                    opt => opt.MapFrom(src => src.IsCompleted));
        }
    }
}

using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.CRM
{
    public class ActivityMappingExtension : Profile
    {
        public ActivityMappingExtension()
        {
            // Persistence Entity -> Domain Entity
            CreateMap<Activity, ActivityDomain>()
                .ForMember(
                    dest => dest.IsCompleted,
                    opt => opt.Ignore());

            // Domain Entity -> Persistence Entity
            CreateMap<ActivityDomain, Activity>()
                .ForMember(
                    dest => dest.IsCompleted,
                    opt => opt.MapFrom(src => src.IsCompleted));
        }
    }
}

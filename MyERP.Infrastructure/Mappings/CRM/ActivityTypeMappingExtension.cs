using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.CRM
{
    public class ActivityTypeMappingExtension : Profile
    {
        public ActivityTypeMappingExtension()
        {
            // Persistence Entity <-> Domain Entity
            CreateMap<ActivityType, ActivityTypeDomain>()
                .ReverseMap();
        }
    }
}

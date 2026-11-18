using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.CRM
{
    public class CustomerNoteMappingExtension : Profile
    {
        public CustomerNoteMappingExtension()
        {
            CreateMap<CustomerNote, CustomerNoteDomain>()
                .ReverseMap();
        }
    }
}

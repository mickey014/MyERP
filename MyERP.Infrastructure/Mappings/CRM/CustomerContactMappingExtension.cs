using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.CRM
{
    public class CustomerContactMappingExtension : Profile
    {
        public CustomerContactMappingExtension()
        {
            CreateMap<CustomerContact, CustomerContactDomain>()
                .ReverseMap();
        }
    }
}

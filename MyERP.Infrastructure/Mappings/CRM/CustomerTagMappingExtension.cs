using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.CRM
{
    public class CustomerTagMappingExtension : Profile
    {
        public CustomerTagMappingExtension()
        {
            CreateMap<CustomerTag, CustomerTagDomain>()
                .ReverseMap();
        }
    }
}

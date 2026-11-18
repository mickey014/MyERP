using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.CRM
{
    public class CustomerMappingExtension : Profile
    {
        public CustomerMappingExtension()
        {
            CreateMap<Customer, CustomerDomain>()
                .ForMember(
                    dest => dest.IsActive, 
                    opt => opt.Ignore());

            CreateMap<CustomerDomain, Customer>()
                .ForMember(
                    dest => dest.IsActive,
                    opt => opt.MapFrom(src => src.IsActive));
        }
    }
}

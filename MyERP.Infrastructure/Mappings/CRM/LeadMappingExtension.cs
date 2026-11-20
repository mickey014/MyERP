using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.CRM
{
    public class LeadMappingExtension : Profile
    {
        public LeadMappingExtension()
        {
            CreateMap<Lead, LeadDomain>().ReverseMap();
        }
    }
}

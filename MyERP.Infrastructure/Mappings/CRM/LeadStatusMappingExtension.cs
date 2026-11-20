using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.CRM
{
    public class LeadStatusMappingExtension : Profile
    {
        public LeadStatusMappingExtension()
        {
            CreateMap<LeadStatus, LeadStatusDomain>().ReverseMap();
        }
    }
}

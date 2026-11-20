using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.CRM
{
    public class OpportunityMappingExtension : Profile
    {
        public OpportunityMappingExtension()
        {
            CreateMap<Opportunity, OpportunityDomain>().ReverseMap();
        }
    }
}

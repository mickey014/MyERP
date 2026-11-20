using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.CRM
{
    public class OpportunityStageMappingExtension : Profile
    {
        public OpportunityStageMappingExtension()
        {
            CreateMap<OpportunityStage, OpportunityStageDomain>().ReverseMap();
        }
    }
}

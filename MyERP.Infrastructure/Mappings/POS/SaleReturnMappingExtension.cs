using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.POS
{
    public class SaleReturnMappingExtension : Profile
    {
        public SaleReturnMappingExtension()
        {
            CreateMap<SaleReturn, SaleReturnDomain>().ReverseMap();
        }
    }
}

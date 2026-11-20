using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.POS
{
    public class SaleReturnItemMappingExtension : Profile
    {
        public SaleReturnItemMappingExtension()
        {
            CreateMap<SaleReturnItem, SaleReturnItemDomain>().ReverseMap();
        }
    }
}

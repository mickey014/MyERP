using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.POS
{
    public class SaleItemMappingExtension : Profile
    {
        public SaleItemMappingExtension()
        {
            CreateMap<SaleItem, SaleItemDomain>().ReverseMap();
        }
    }
}

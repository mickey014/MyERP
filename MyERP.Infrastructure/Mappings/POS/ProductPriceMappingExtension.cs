using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.POS
{
    public class ProductPriceMappingExtension : Profile
    {
        public ProductPriceMappingExtension()
        {
            CreateMap<ProductPrice, ProductPriceDomain>().ReverseMap();
        }
    }
}

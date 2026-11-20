using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.POS
{
    public class ProductMappingExtension : Profile
    {
        public ProductMappingExtension()
        {
            CreateMap<Product, ProductDomain>().ReverseMap();
        }
    }
}

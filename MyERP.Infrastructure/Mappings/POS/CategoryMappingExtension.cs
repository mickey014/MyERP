using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.POS
{
    public class CategoryMappingExtension : Profile
    {
        public CategoryMappingExtension()
        {
            CreateMap<Category, CategoryDomain>()
                .ForMember(
                    dest => dest.IsActive,
                    opt => opt.Ignore());

            CreateMap<CategoryDomain, Category>()
                .ForMember(
                    dest => dest.IsActive,
                    opt => opt.MapFrom(src => src.IsActive));
        }
    }
}

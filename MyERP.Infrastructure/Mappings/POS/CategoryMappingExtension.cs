using AutoMapper;
using MyERP.Application.DTOs.Response.Category;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.POS
{
    public class CategoryMappingExtension : Profile
    {
        public CategoryMappingExtension()
        {
            // EF Entity -> Domain
            CreateMap<Category, CategoryDomain>();

            // Domain -> EF Entity
            CreateMap<CategoryDomain, Category>()
                .ForMember(
                    dest => dest.IsActive,
                    opt => opt.MapFrom(src => src.IsActive));

            // Domain -> Response DTO
            CreateMap<CategoryDomain, CategoryResponseDto>();

            // EF Entity -> Response DTO
            CreateMap<Category, CategoryResponseDto>()
                .ForMember(
                    dest => dest.ProductCount,
                    opt => opt.MapFrom(src => src.Products.Count));
        }
    }
}

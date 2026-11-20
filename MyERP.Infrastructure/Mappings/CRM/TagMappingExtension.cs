using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.CRM
{
    public class TagMappingExtension : Profile
    {
        public TagMappingExtension()
        {
            CreateMap<Tag, TagDomain>().ReverseMap();
        }
    }
}

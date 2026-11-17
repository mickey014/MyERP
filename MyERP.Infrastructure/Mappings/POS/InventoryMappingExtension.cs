using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.POS
{
    public class InventoryMappingExtension : Profile
    {
        public InventoryMappingExtension()
        {
            // Persistence Entity <-> Domain Entity
            CreateMap<Inventory, InventoryDomain>()
                .ReverseMap();
        }
    }
}

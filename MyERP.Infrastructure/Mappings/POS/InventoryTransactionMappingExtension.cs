using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.POS
{
    public class InventoryTransactionMappingExtension : Profile
    {
        public InventoryTransactionMappingExtension()
        {
            CreateMap<InventoryTransaction, InventoryTransactionDomain>()
                .ForMember(
                    dest => dest.TransactionType,
                    opt => opt.Ignore());

            CreateMap<InventoryTransactionDomain, InventoryTransaction>()
                .ForMember(
                    dest => dest.TransactionType,
                    opt => opt.MapFrom(src => src.TransactionType));
        }
    }
}

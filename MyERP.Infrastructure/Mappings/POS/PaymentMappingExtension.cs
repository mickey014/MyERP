using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.POS
{
    public class PaymentMappingExtension : Profile
    {
        public PaymentMappingExtension()
        {
            CreateMap<Payment, PaymentDomain>().ReverseMap();
        }
    }
}

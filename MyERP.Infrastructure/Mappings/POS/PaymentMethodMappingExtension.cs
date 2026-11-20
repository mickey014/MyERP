using AutoMapper;
using MyERP.Domain.DomainEntities;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Mappings.POS
{
    public class PaymentMethodMappingExtension : Profile
    {
        public PaymentMethodMappingExtension()
        {
            CreateMap<PaymentMethod, PaymentMethodDomain>()
                .ForMember(
                    dest => dest.IsActive,
                    opt => opt.Ignore());

            CreateMap<PaymentMethodDomain, PaymentMethod>()
                .ForMember(
                    dest => dest.IsActive,
                    opt => opt.MapFrom(src => src.IsActive));
        }
    }
}

using AutoMapper;
using FinCtrl.Backend.Core.RestAPI.DAL.DTO.ModelDTO;
using FinCtrl.Backend.Core.RestAPI.DAL.Models;

namespace FinCtrl.Backend.Core.RestAPI
{
    public class DTOMappingProfile : Profile
    {
        public DTOMappingProfile()
        {
            CreateMap<CategoryDTO, Category>();
            CreateMap<PaymentSourceDTO, PaymentSource>();
            CreateMap<PaymentDTO, Payment>();
        }
    }
}

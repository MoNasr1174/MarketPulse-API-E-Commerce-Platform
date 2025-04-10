using AutoMapper;
using MarketPulse.APIs.Dtos;
using MarketPulse.Core.Entities;

namespace MarketPulse.APIs.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>().
                ForMember(d => d.Category, O => O.MapFrom(O => O.Category.Name))
                .ForMember(d => d.Brand, O => O.MapFrom(O => O.Brand.Name))
                .ForMember(d => d.PictureUrl, O => O.MapFrom<ProductPictureUrlResolver>());  
        }

    }
}

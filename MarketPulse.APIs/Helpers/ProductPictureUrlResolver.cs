using AutoMapper;
using MarketPulse.APIs.Dtos;
using MarketPulse.Core.Entities;

namespace MarketPulse.APIs.Helpers
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{_configuration["APIBaseUrl"]}/{source.PictureUrl}";

                return string.Empty;



            }
        }
    }



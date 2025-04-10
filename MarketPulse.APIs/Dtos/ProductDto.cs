using MarketPulse.Core.Entities;

namespace MarketPulse.APIs.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public decimal Price { get; set; }


        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        public string Brand { get; set; }

        public string Category { get; set; }

    }
}

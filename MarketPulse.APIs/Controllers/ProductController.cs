using AutoMapper;
using MarketPulse.APIs.Dtos;
using MarketPulse.Core.Entities;
using MarketPulse.Core.IGenericRepository;
using MarketPulse.Core.Specifications.ProductSpecifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPulse.APIs.Controllers
{

    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper  ,IGenericRepository<Product> productRepository) 
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var Spec = new ProductWithBrandandCategorySpecifications();
            var products = await _productRepository.GetAllWithSpecAsync(Spec);
            var ProductsDTO = _mapper.Map< IEnumerable<Product>, IEnumerable<ProductDto>>(products);

            return Ok(ProductsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductByID(int id)
        {
            var Spec = new ProductWithBrandandCategorySpecifications(id);
            var product =  await _productRepository.GetByIdWithSpecAsync(Spec);    
            if (product == null)
                return NotFound();
            var ProductDTO = _mapper.Map<Product, ProductDto>(product);
            return Ok(ProductDTO);
        }

    }
}

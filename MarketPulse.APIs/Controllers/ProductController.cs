using MarketPulse.Core.Entities;
using MarketPulse.Core.IGenericRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPulse.APIs.Controllers
{

    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;
        public ProductController(IGenericRepository<Product> productRepository) 
        {
            _productRepository = productRepository;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
             
            var products = await _productRepository.GetAllAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductByID(int id)
        {
             var product =  await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

    }
}

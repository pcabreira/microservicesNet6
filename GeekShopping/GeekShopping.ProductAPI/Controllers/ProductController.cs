using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("FindAll")]
        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _repository.FindAll();
            return products;
        }

        [HttpGet("FindById/{id}")]
        public async Task<ProductVO> FindById(long id)
        {
            var product = await _repository.FindById(id);
            return product;
        }

        [HttpPost("Create")]
        public async Task<ProductVO> Create(ProductVO product)
        {
            var productCreated = await _repository.Create(product);
            return productCreated;
        }

        [HttpPut("Update")]
        public async Task<ProductVO> Update(ProductVO product)
        {
            var productUpdated = await _repository.Update(product);
            return productUpdated;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<bool> Delete(long id)
        {
            var status = await _repository.Delete(id);
            return status;
        }
    }
}

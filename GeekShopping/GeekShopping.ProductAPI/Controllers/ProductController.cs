using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Interfaces;
using GeekShopping.ProductAPI.Utils;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _repository.FindAll();
            return products;
        }

        [HttpGet("{id}")]
        public async Task<ProductVO> FindById(long id)
        {
            var product = await _repository.FindById(id);
            return product;
        }

        [Authorize]
        [HttpPost]
        public async Task<ProductVO> Create([FromBody]ProductVO product)
        {
            var productCreated = await _repository.Create(product);
            return productCreated;
        }

        [Authorize]
        [HttpPut]
        public async Task<ProductVO> Update([FromBody]ProductVO product)
        {
            var productUpdated = await _repository.Update(product);
            return productUpdated;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<bool> Delete(long id)
        {
            var status = await _repository.Delete(id);
            return status;
        }
    }
}

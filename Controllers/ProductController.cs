using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIProduct.DTOs;
using APIProduct.Models;
using APIProduct.Repo;

namespace APIProduct.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repo;

        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll([FromQuery] string? name, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            var products = await _repo.GetFilteredProducts(name, minPrice, maxPrice);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _repo.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(ProductDTO dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price
            };
            await _repo.Create(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDTO dto)
        {
            var existing = await _repo.GetById(id);
            if (existing == null) return NotFound();

            existing.Name = dto.Name;
            existing.Description = dto.Description;
            existing.Price = dto.Price;
            await _repo.Update(existing);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _repo.GetById(id);
            if (product == null) return NotFound();

            await _repo.Delete(product);
            return NoContent();
        }


    }
}

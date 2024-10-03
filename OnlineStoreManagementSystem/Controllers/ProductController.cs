using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreManagementSystem.Models;
using OnlineStoreManagementSystem.Models.Product;
using OnlineStoreManagementSystem.Repositories.Contracts;

namespace OnlineStoreManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductRepository productRepository) : ControllerBase
    {
        // GET: api/<ProductController>
        [HttpPost("query")]
        public async Task<BaseCollectionVM<ProductVM>> Get([FromBody] PaginationOptions pagination, CancellationToken cf = default)
        {
            return await productRepository.GetAllPaginatedAsync(pagination, cf);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductVM>> Get(Guid id, CancellationToken cf = default)
        {
            var product = await productRepository.GetByIdAsync(id, cf);

            if (product != null)
            {
                return product;
            }

            return NotFound();
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<ProductVM>> Post([FromBody] ProductIM im, CancellationToken cf = default)
        {
            try
            {
                return await productRepository.CreateAsync(im, cf);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProductVM?>> Put(Guid id, [FromBody] ProductUM um)
        {
            try
            {
                return await productRepository.UpdateByIdAsync(id, um);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var affectedRows = await productRepository.DeleteByIdAsync(id);

            if (affectedRows == 0)
                return NotFound();

            return Ok();
        }
    }
}

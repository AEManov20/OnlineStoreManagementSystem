using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreManagementSystem.Models;
using OnlineStoreManagementSystem.Models.Order;
using OnlineStoreManagementSystem.Repositories.Contracts;

namespace OnlineStoreManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderRepository orderRepository) : ControllerBase
    {
        // GET: api/<OrderController>
        [HttpPost("query")]
        public async Task<BaseCollectionVM<OrderVM>> Query([FromBody] PaginationOptions pagination, CancellationToken cf = default)
        {
            return await orderRepository.GetAllPaginatedAsync(pagination, cf);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OrderVM>> Get(Guid id)
        {
            var order = await orderRepository.GetByIdAsync(id);

            if (order != null)
                return order;

            return NotFound();
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<OrderVM>> Post([FromBody] OrderAdminIM im)
        {
            return await orderRepository.CreateAsync(im);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<OrderVM>> Put(Guid id, [FromBody] OrderUM um, CancellationToken cf = default)
        {
            try
            {
                var order = await orderRepository.UpdateByIdAsync(id, um, cf);
                
                if (order != null)
                    return order;
                
                return NotFound();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cf = default)
        {
            var affectedRows = await orderRepository.DeleteByIdAsync(id, cf);

            if (affectedRows == 0)
                return NotFound();

            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreManagementSystem.Models;
using OnlineStoreManagementSystem.Models.Customer;
using OnlineStoreManagementSystem.Repositories.Contracts;

namespace OnlineStoreManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(ICustomerRepository customerRepository) : ControllerBase
{
    // GET: api/<CustomerController>
    [HttpPost("query")]
    public async Task<BaseCollectionVM<CustomerVM>> Query([FromBody] PaginationOptions pagination, CancellationToken cf = default)
    {
        return await customerRepository.GetAllPaginatedAsync(pagination, cf);
    }

    // GET api/<CustomerController>/5
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CustomerVM>> Get(Guid id)
    {
        var customer = await customerRepository.GetByIdAsync(id);

        if (customer != null)
        {
            return customer;
        }

        return NotFound();
    }

    // POST api/<CustomerController>
    [HttpPost]
    public async Task<ActionResult<CustomerVM>> Post([FromBody] CustomerIM im)
    {
        return await customerRepository.CreateAsync(im);
    }

    // PUT api/<CustomerController>/5
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<CustomerVM>> Put(Guid id, [FromBody] CustomerUM um)
    {
        var customer = await customerRepository.UpdateByIdAsync(id, um);
        
        if (customer != null)
            return customer;

        return NotFound();
    }

    // DELETE api/<CustomerController>/5
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var affectedRows = await customerRepository.DeleteByIdAsync(id);

        if (affectedRows == 0)
            return NotFound();

        return Ok();
    }
}

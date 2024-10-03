using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreManagementSystem.Models;
using OnlineStoreManagementSystem.Models.DiscountCode;
using OnlineStoreManagementSystem.Repositories.Contracts;

namespace OnlineStoreManagementSystem.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DiscountCodeController : ControllerBase
{
    private IDiscountCodeRepository _discountCodeRepository;
    
    // GET: api/<DiscountCodeController>
    [HttpPost("query")]
    public async Task<BaseCollectionVM<DiscountCodeVM>> Get([FromBody] PaginationOptions pagination, CancellationToken cf = default)
    {
        return await _discountCodeRepository.GetAllPaginatedAsync(pagination, cf);
    }

    // GET api/<DiscountCodeController>/5
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<DiscountCodeVM>> Get(Guid id, CancellationToken cf = default)
    {
        var discount = await _discountCodeRepository.GetByIdAsync(id, cf);

        if (discount != null)
            return discount;

        return NotFound();
    }

    // POST api/<DiscountCodeController>
    [HttpPost]
    public async Task<ActionResult<DiscountCodeVM>> Post([FromBody] DiscountCodeIM im, CancellationToken cf)
    {
        return await _discountCodeRepository.CreateAsync(im, cf);
    }

    // PUT api/<DiscountCodeController>/5
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<DiscountCodeVM>> Put(Guid id, [FromBody] DiscountCodeUM um, CancellationToken cf)
    {
        var discount = await _discountCodeRepository.UpdateByIdAsync(id, um, cf);

        if (discount != null)
            return discount;

        return NotFound();
    }

    // DELETE api/<DiscountCodeController>/5
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var affectedRows = await _discountCodeRepository.DeleteByIdAsync(id);

        if (affectedRows == 0)
            return NotFound();
        else return Ok();
    }
}

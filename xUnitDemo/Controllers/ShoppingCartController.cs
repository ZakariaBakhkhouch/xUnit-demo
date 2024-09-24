using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using xUnitDemo.Models;
using xUnitDemo.Services;

namespace xUnitDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        public ShoppingCartController(IShoppingCartService service)
        {
            _shoppingCartService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _shoppingCartService.GetAllItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var item = _shoppingCartService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ShoppingItem value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _shoppingCartService.Add(value);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            var existingItem = _shoppingCartService.GetById(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            _shoppingCartService.Remove(id);
            return NoContent();
        }
    }
}

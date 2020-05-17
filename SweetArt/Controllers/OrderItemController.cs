using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetArt.Models;

namespace SweetArt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        CakeContext db;

        public OrderItemController(CakeContext context)
        {
            db = context;
            if (!db.OrderItems.Any())
            {
                db.OrderItems.Add(new OrderItem { Id = Guid.NewGuid(), OrderId = Guid.Parse("5ff326e1-a8de-428b-851a-eb2ef38d24a7"), ProductId = Guid.Parse("15760DD1-EF0C-4C92-9E3E-CC6DF9DD14AC"), Quantity = 2 });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> Get()
        {
            return await db.OrderItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> Get(Guid id)
        {
            OrderItem orderItem = await db.OrderItems.FirstOrDefaultAsync(x => x.Id == id);
            if (orderItem == null)
                return NotFound();
            return new ObjectResult(orderItem);
        }

        [HttpPost]
        public async Task<ActionResult<OrderItem>> Post(OrderItem orderItem)
        {
            if (orderItem == null)
            {
                return BadRequest();
            }

            db.OrderItems.Add(orderItem);
            await db.SaveChangesAsync();
            return Ok(orderItem);
        }

        [HttpPut]
        public async Task<ActionResult<OrderItem>> Put(OrderItem orderItem)
        {
            if (orderItem == null)
            {
                return BadRequest();
            }
            if (!db.Categories.Any(x => x.Id == orderItem.Id))
            {
                return NotFound();
            }

            db.Update(orderItem);
            await db.SaveChangesAsync();
            return Ok(orderItem);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderItem>> Delete(Guid id)
        {
            OrderItem orderItem = db.OrderItems.FirstOrDefault(x => x.Id == id);
            if (orderItem == null)
            {
                return NotFound();
            }
            db.OrderItems.Remove(orderItem); 
            await db.SaveChangesAsync();
            return Ok(orderItem);
        }
    }
}
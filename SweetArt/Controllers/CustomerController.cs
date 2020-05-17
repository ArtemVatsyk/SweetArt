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
    public class CustomerController : Controller
    {
        CakeContext db;
        public CustomerController(CakeContext context)
        {
            db = context;
            if (!db.Customers.Any())
            {
                db.Customers.Add(new Customer { Id = Guid.NewGuid(), Address = "Vovchentska 158", Email = "vasia@gmail.com", FirstName = "Anton", LastName = "Shevchenko", Phone = "0688052005"});
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            return await db.Customers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(Guid id)
        {
            Customer customer = await db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
                return NotFound();
            return new ObjectResult(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Post(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            db.Customers.Add(customer);
            await db.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpPut]
        public async Task<ActionResult<Customer>> Put(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            if (!db.Customers.Any(x => x.Id == customer.Id))
            {
                return NotFound();
            }

            db.Update(customer);
            await db.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(Guid id)
        {
            Customer customer = db.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            db.Customers.Remove(customer);
            await db.SaveChangesAsync();
            return Ok(customer);
        }
    }
}

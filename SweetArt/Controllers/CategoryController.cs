using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetArt.Models;

namespace SweetArt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        CakeContext db;
        public CategoryController(CakeContext context)
        {
            db = context;
            if (!db.Categories.Any())
            {
                db.Categories.Add(new Category { Id = Guid.NewGuid(), Name = "Wedding cake"});
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return await db.Categories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(Guid id)
        {
            Category category = await db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound();
            return new ObjectResult(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Post(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return Ok(category);
        }

        [HttpPut]
        public async Task<ActionResult<Category>> Put(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            if (!db.Categories.Any(x => x.Id == category.Id))
            {
                return NotFound();
            }

            db.Update(category);
            await db.SaveChangesAsync();
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> Delete(Guid id)
        {
            Category category = db.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
            return Ok(category);
        }
    }
}

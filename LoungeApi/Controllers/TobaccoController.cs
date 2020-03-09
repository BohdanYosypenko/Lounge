using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoungeApi.Models;
using LoungeApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoungeApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TobaccoController : ControllerBase
    {
        LoungeContext db;
        public TobaccoController(LoungeContext context)
        {
            db = context;
            if (!db.Tobaccos.Any())
            {
                db.Tobaccos.Add(new Tobacco { Name = "Tom", Taste = "26", Description = "das is good", Image = "https://previews.123rf.com/images/sergarck/sergarck1608/sergarck160800044/63290717-legs-of-beautiful-model-covered-with-short-preaty-skirt-isolated-on-white-background-.jpg", Weight = 23 });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tobacco>>> Get()
        {
            return await db.Tobaccos.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tobacco>> Get(int id)
        {
            Tobacco user = await db.Tobaccos.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Tobacco>> Post(Tobacco user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            db.Tobaccos.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Tobacco>> Put(Tobacco user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!db.Tobaccos.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            db.Update(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tobacco>> Delete(int id)
        {
            Tobacco user = db.Tobaccos.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Tobaccos.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }

}
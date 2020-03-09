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
    public class OrderController : ControllerBase
    {
        LoungeContext db;
        public OrderController(LoungeContext context)
        {
            db = context;
            if (!db.Orders.Any())
            {
                db.Orders.Add(new Order { User = "Петро Курець", Address = "NewAdress", ContactPhone = "newPhone",TobaccoId=1 });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            return await db.Orders.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            Order order = await db.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
                return NotFound();
            return new ObjectResult(order);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Order>> Post(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            db.Orders.Add(order);
            await db.SaveChangesAsync();
            return Ok(order);
        }

        // PUT api/users/
        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> Put(int id,Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            if (!db.Orders.Any(x => x.Id == id))
            {
                return NotFound();
            }

            db.Update(order);
            await db.SaveChangesAsync();
            return Ok(order);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tobacco>> Delete(int id)
        {
            Order order = db.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            db.Orders.Remove(order);
            await db.SaveChangesAsync();
            return Ok(order);
        }
    }
}
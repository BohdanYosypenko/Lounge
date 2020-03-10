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
        public async Task<IEnumerable<Tobacco>> Get()
        {
            return await db.Tobaccos.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<Tobacco> Get(int id)
        {
            Tobacco tobacco = await db.Tobaccos.FirstOrDefaultAsync(x => x.Id == id);
            if (tobacco == null)
                return null;
            return tobacco;
        }

        // POST api/users
        [HttpPost]
        public async Task<Tobacco> Post(Tobacco tobacco)
        {
            if (tobacco == null)
            {
                return null;
            }

            db.Tobaccos.Add(tobacco);
            await db.SaveChangesAsync();
            return tobacco;
        }

        // PUT api/users/
        [HttpPut]
        public async Task<Tobacco> Put(Tobacco tobacco)
        {
            if (tobacco == null)
            {
                return null;
            }
            if (!db.Tobaccos.Any(x => x.Id == tobacco.Id))
            {
                return null  ;
            }

            db.Update(tobacco);
            await db.SaveChangesAsync();
            return tobacco;
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<Tobacco> Delete(int id)
        {
            Tobacco tobacco = db.Tobaccos.FirstOrDefault(x => x.Id == id);
            if (tobacco == null)
            {
                return null;
            }
            db.Tobaccos.Remove(tobacco);
            await db.SaveChangesAsync();
            return tobacco;
        }
    }

}
using LoungeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LoungeApi.Services
{
    public class LoungeContext:DbContext
    {
        public DbSet<Tobacco> Tobaccos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public LoungeContext(DbContextOptions<LoungeContext> options)  
            : base(options)
        {
           
            Database.EnsureCreated();
        }
    }
}

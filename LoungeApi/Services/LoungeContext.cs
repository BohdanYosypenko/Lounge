using LoungeApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

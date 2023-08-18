using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Persistence.Contexts
{
    public class BaseDbContext:DbContext
    {

        protected IConfiguration Configuration { get; set; }
        public DbSet<Brand> Brands { get; set; }  
        
        public BaseDbContext(DbContextOptions dbContextOptions , IConfiguration configuration) : base(dbContextOptions)
        {

            Configuration = configuration;
            Database.EnsureCreated();   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //mevcut assemblydeki configurationları bul ve uygula
          modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 

        }

    }
}

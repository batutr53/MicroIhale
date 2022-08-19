using MicroIhale.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MicroIhale.Infrastructure.Data
{
    public class WebAppContext:IdentityDbContext<AppUser>
    {
        public WebAppContext(DbContextOptions<WebAppContext> options):base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);


        }
    }
}

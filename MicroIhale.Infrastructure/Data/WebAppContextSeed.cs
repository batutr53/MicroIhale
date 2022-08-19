using MicroIhale.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroIhale.Infrastructure.Data
{
    public class WebAppContextSeed:IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(new AppUser()
            {
                FirstName="User",
                LastName="User Last",
                IsSeller=true,
                IsBuyer=false,
            }
            );
         }
    }
}

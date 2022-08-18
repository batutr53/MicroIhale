using MicroIhale.Core.Entities;
using MicroIhale.Core.Repositoires;
using MicroIhale.Infrastructure.Data;
using MicroIhale.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroIhale.Infrastructure.Repository
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        private readonly WebAppContext _context;
        public UserRepository(WebAppContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}

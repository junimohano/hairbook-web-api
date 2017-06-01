using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairbookWebApi.Database;
using HairbookWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HairbookWebApi.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(HairbookContext context) : base(context)
        {
        }
    }
}

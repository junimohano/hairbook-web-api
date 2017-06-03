using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairbookWebApi.Models;

namespace HairbookWebApi.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository Users { get; }
        ISalonsRepository Salons { get; }
        IPostsRepository Posts { get; }
        Task<int> Complete();
    }
}

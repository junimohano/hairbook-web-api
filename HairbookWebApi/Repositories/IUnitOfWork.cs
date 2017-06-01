using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairbookWebApi.Models;

namespace HairbookWebApi.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        Task<int> Complete();
    }
}

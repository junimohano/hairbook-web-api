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
        IUserFriendsRepository UserFriends { get; }
        ISalonsRepository Salons { get; }

        IPostsRepository Posts { get; }
        IPostEvaluationsRepository PostEvaluations { get; }
        IPostUploadsRepository PostUploads { get; }

        IMemosRepository Memos { get; }
        IMemoEvaluationsRepository MemoEvaluations { get; }
        IMemoUploadsRepository MemoUploads { get; }

        Task<int> Complete();
    }
}

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
        IPostCommentsRepository PostComments { get; }
        IPostFavoritesRepository PostFavorites { get; }


        Task<int> Complete();
    }
}

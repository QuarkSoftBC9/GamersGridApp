using GamersGrid.BLL.Repositories;
using GamersGrid.BLL.Repositories.Interfaces;

namespace GamersGrid.BLL
{
    public interface IUnitOfWork
    {
        IFollowRelationsRepository FollowRelations { get;  }
        IGameAccountRepository GameAccounts { get;  }
        IGameAccountStatsRepository GameAccountStats { get;  }
        IVideoGamesRepository Games { get;  }
        IGGUserRepository GGUsers { get;  }
        IUserGameRelationsRepository UsersGamesRelations { get;  }

        void Save();
    }
}
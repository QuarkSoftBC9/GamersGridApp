using GamersGrid.BLL.Repositories;

namespace GamersGrid.BLL
{
    public interface IUnitOfWork
    {
        FollowRelationsRepository FollowRelations { get; set; }
        GameAccountRepository GameAccounts { get; set; }
        GameAccountStatsRepository GameAccountStats { get; set; }
        VideoGamesRepository Games { get; set; }
        GGUserRepository GGUsers { get; set; }
        UserGameRelationsRepository UsersGamesRelations { get; set; }

        void Save();
    }
}
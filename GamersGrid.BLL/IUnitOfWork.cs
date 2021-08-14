using GamersGrid.BLL.Repositories.Interfaces;
using GamersGrid.DAL;
using System.Threading.Tasks;

namespace GamersGrid.BLL
{
    public interface IUnitOfWork
    {
        ApplicationDbContext db { get; }
        IFollowRelationsRepository FollowRelations { get; }
        IGameAccountRepository GameAccounts { get; }
        IGameAccountStatsRepository GameAccountStats { get; }
        IVideoGamesRepository Games { get; }
        IGGUserRepository GGUsers { get; }
        IUserGameRelationsRepository UsersGamesRelations { get; }

        Task Save();
    }
}
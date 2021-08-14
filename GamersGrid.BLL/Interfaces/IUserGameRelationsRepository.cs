using GamersGrid.BLL.Interfaces.Abstractions;
using GamersGrid.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamersGrid.BLL.Repositories.Interfaces
{
    public interface IUserGameRelationsRepository : IRepository<UsersGamesRelation>
    {
        void Add(UsersGamesRelation userGame);
        Task<IEnumerable<int>> GetGamesIdFocus(VideoGame game);
    }
}
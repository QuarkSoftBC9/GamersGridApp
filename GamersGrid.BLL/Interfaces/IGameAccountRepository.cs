using GamersGrid.BLL.Interfaces.Abstractions;
using GamersGrid.DAL.Models;
using System.Threading.Tasks;

namespace GamersGrid.BLL.Repositories.Interfaces
{
    public interface IGameAccountRepository : IRepository<GameAccount>
    {
        Task<GameAccount> GetGameAccByNameAndRegion(string nickName, string region);
    }
}
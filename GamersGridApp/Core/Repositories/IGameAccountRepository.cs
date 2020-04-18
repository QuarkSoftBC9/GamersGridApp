using GamersGridApp.Core.Models;

namespace GamersGridApp.Core.Repositories
{
    public interface IGameAccountRepository
    {
        GameAccount GetGameAccByNameAndRegion(string nickName, string region);
    }
}
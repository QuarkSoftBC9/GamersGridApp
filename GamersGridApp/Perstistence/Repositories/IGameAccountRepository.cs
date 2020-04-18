using GamersGridApp.Models;

namespace GamersGridApp.Repositories
{
    public interface IGameAccountRepository
    {
        GameAccount GetGameAccByNameAndRegion(string nickName, string region);
    }
}
using GamersGrid.BLL.Interfaces.Abstractions;
using GamersGrid.DAL.Models;
using System.Threading.Tasks;

namespace GamersGrid.BLL.Repositories.Interfaces
{
    public interface IVideoGamesRepository : IRepository<VideoGame>
    {
        Task<VideoGame> GetFavouriteGame(int favoriteGameId);
        Task<int> GetFavouriteGameId(int UserId);
        Task<string> GetFavouriteGameTitle(int favoriteGameId);
        Task<VideoGame> GetGame(string title);
        Task<int> GetGameId(string title);
    }
}
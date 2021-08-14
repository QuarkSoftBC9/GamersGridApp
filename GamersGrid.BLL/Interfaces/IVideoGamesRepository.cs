using GamersGrid.BLL.Interfaces.Abstractions;
using GamersGrid.DAL.Models;
using System.Threading.Tasks;

namespace GamersGrid.BLL.Repositories.Interfaces
{
    public interface IVideoGamesRepository : IRepository<VideoGame>
    {
        Task<VideoGame> GetFavouriteGameAsync(int favoriteGameId);
        Task<int> GetFavouriteGameIdAsync(int UserId);
        Task<string> GetFavouriteGameTitleAsync(int favoriteGameId);
        Task<VideoGame> GetGameAsync(string title);
        Task<int> GetGameIdAsync(string title);
    }
}
using GameStore.App.Data.Models;
using GameStore.App.Models.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.App.Services.Contracts
{
    public interface IGameService
    {
        void Create(string title, decimal price, double size, string videoId, string thumbnailUrl, string description, DateTime releaseDate);

        IEnumerable<GameListingAdminModel> All();

        Game GetById(int id);
        void Update(int id, string title, decimal price, double size, string videoId, string thumbnailUrl, string description, DateTime releaseDate);
    }
}

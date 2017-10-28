

namespace GameStore.App.Services
{
    using Services.Contracts;
    using System.Collections.Generic;
    using Models.Games;
    using Data;
    using System.Linq;
    using System;
    using GameStore.App.Data.Models;

    public class GameService : IGameService
    {
        private readonly GameStoreDbContext db;

        public GameService(GameStoreDbContext db)
        {
            this.db = db;
        }


        public void Create(string title, decimal price, double size, string videoId, string thumbnailUrl, string description, DateTime releaseDate)
        {

            var game = new Game
            {
                Title = title,
                Price = price,
                Size = size,
                VideoId = videoId,
                ThumbnailUrl = thumbnailUrl,
                Description = description,
                ReleaseDate = releaseDate

            };

            this.db.Games.Add(game);
            this.db.SaveChanges();

        }

        public IEnumerable<GameListingAdminModel> All()
        {

            return this.db
                  .Games
                  .Select(g => new GameListingAdminModel
                  {
                      Id = g.Id,
                      Name = g.Title,
                      Price = g.Price,
                      Size = g.Size
                  });

        }

        public Game GetById(int id)
            => this.db.Games.Find(id);


        public void Update(int id, string title, decimal price, double size, string videoId, string thumbnailUrl, string description, DateTime releaseDate)
        {

            var game = db.Games.Find(id);

            game.Title = title;
            game.Price = price;
            game.Size = size;
            game.VideoId = videoId;
            game.ThumbnailUrl = thumbnailUrl;
            game.Description = description;
            game.ReleaseDate = releaseDate;
            this.db.SaveChanges();
        }
    }
}

﻿

namespace GameStore.App.Controllers
{

    using GameStore.App.Models.Games;
    using GameStore.App.Services;
    using GameStore.App.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using System.Linq;

    public class AdminController : BaseController
    {
        public const string GameError = "< p > Check your form for errors.</p><p>Title has to begin with uppercase letter and has length between 3 and 100 symbols(inclusive).</p><p>Price must be a positive number with precision up to 2 digits after floating point.</p><p>Size must be a positive number with precision up to 1 digit after floating point.</p><p>Videos should only be from YouTube.</p><p>Thumbnail URL should be a plain text starting with http://, https://.</p><p>Description must be at least 20 symbols.</p>";


        private readonly IGameService games;

        public AdminController(IGameService games)
        {
            this.games = games;
        }

        public IActionResult Add()
        {
            if (!this.IsAdmin)
            {
                return this.Redirect("/");
            }

            return this.View();
        }


        [HttpPost]
        public IActionResult Add (GameAdminModel model)
        {
            if (!this.IsAdmin)
            {
                return this.Redirect("/");
            }


            if(!this.IsValidModel(model))
            {
                this.ShowError(GameError);
                return this.View();
            }

            this.games.Create(
                model.Title,
                model.Price,
                model.Size,
                model.VideoId,
                model.ThumbnailUrl,
                model.Description,
                model.ReleaseDate);

               return this.Redirect("/admin/all");


        }



        public IActionResult All()
        {
            if(!this.Profile.IsAdmin)
            {
                return this.Redirect("/");
            }


            var allGames = this.games
               .All()
               .Select(g => $@"
                    <tr>
                        <td>{g.Id}</td>
                        <td>{g.Name}</td>
                        <td>{g.Size} GB</td>
                        <td>{g.Price} &euro;</td>
                        <td>
                            <a class=""btn btn-warning btn-sm"" href=""/admin/edit?id={g.Id}"">Edit</a>
                            <a class=""btn btn-danger btn-sm"" href=""/admin/delete?id={g.Id}"">Delete</a>
                        </td>
                    </tr>");



            this.ViewModel["games"] = string.Join(string.Empty, allGames);

            return this.View();
        }

        public IActionResult Edit (int id)
        {
            if (!this.Profile.IsAdmin)
            {
                return this.Redirect("/");
            }

            var game = this.games.GetById(id);


            if(game == null)
            {
                return this.NotFound();

            }

            this.ViewModel["title"] = game.Title;
            this.ViewModel["description"] = game.Description;
            this.ViewModel["price"] = game.Price.ToString("F2");
            this.ViewModel["video-id"] = game.VideoId;
            this.ViewModel["size"] = game.Size.ToString("F2");
            this.ViewModel["release-date"] = game.ReleaseDate.ToString("yyy-MM-dd");
            this.ViewModel["thumbnail"] = game.ThumbnailUrl;

            return this.View();
        }

        [HttpPost]
        public IActionResult Edit (int id, GameAdminModel model)
        {
            if (!this.Profile.IsAdmin)
            {
                return this.Redirect("/");
            }

            if (!this.IsValidModel(model))
            {
                this.ShowError(GameError);
                return this.View();
            }


            this.games.Update(
                id,
                model.Title,
                model.Price,
                model.Size,
                model.VideoId,
                model.ThumbnailUrl,
                model.Description,
                model.ReleaseDate);

            return this.Redirect("/admin/all");
        }
         
    }
}

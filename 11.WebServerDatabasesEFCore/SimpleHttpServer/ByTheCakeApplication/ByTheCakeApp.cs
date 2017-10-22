
namespace SimpleHttpServer.ByTheCakeApplication
{
    using Controllers;
    using SampleHttpServer.Server.Contracts;
    using SampleHttpServer.Server.Routing.Contracts;

    public class ByTheCakeApp : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig
                .Get("/", req => new HomeController().Index());

            appRouteConfig
                .Get("/about", req => new HomeController().About());

            appRouteConfig
                .Get("/add", req => new CakesController().Add());

            appRouteConfig
               .Post("/add", req => new CakesController().Add(req.FormData["name"], req.FormData["price"]));


            appRouteConfig
                .Get("/search", req => new CakesController().Search(req));

            appRouteConfig
                .Get("/login", req => new AccoutController().Login());

            appRouteConfig
              .Post("/login", req => new AccoutController().Login(req));

            appRouteConfig
                .Post("/logout", req => new AccoutController().Logout(req));

            appRouteConfig
                .Get("/shopping/add/{(?<id>[0-9]+)}", req => new ShoppingController().AddToCard(req));

            appRouteConfig
                .Get("/cart", req => new ShoppingController().ShowCart(req));

            appRouteConfig
                .Post("/shopping/finish-order", req => new ShoppingController().FinishOrder(req));


        }
    }
}


namespace SimpleHttpServer.ByTheCakeApplication.Controllers
{
    using SampleHttpServer.Server.Http.Contracts;
    using SampleHttpServer.Server.Http.Response;
    using SimpleHttpServer.ByTheCakeApplication.Data;
    using SimpleHttpServer.ByTheCakeApplication.Infrastructures;
    using SimpleHttpServer.ByTheCakeApplication.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingController : Controller
    {
        private readonly CakesData cakesData;
        public ShoppingController()
        {
            this.cakesData = new CakesData();
        }
        public IHttpResponse AddToCard(IHttpRequest req)
        {
            var idNumber = int.Parse(req.UrlParameters["id"]);
            var cake = this.cakesData.Find(idNumber);

            if (cake == null)
            {
                return new NotFoundResponse();
            }
            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);
            shoppingCart.Orders.Add(cake);

            const string searchTermKey = "searchTerm";

            var redirectUrl = "/search";
            if (req.UrlParameters.ContainsKey(searchTermKey))
            {
                redirectUrl = $"{redirectUrl}?{searchTermKey}={req.UrlParameters[searchTermKey]}";
            }
            return new RedirectResponse(redirectUrl);
        }

        public IHttpResponse FinishOrder(IHttpRequest req)
        {
            req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey).Orders.Clear();

          return  this.FileViewResponse("shopping/finish-order");
        }

        public IHttpResponse ShowCart(IHttpRequest req)
        {
            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);
            if(!shoppingCart.Orders.Any())
            {
                this.ViewData["cartItems"] = "No items in your cart.";
                this.ViewData["totalCost"] = "0.00";
            }
            else
            {
                var items = shoppingCart
                    .Orders
                    .Select(i => $"<li>{i.Name} - ${i.Price:F2}</li>");

                this.ViewData["cartItems"] = string.Join(string.Empty, items);

                var totalPrice = shoppingCart
                    .Orders
                    .Sum(i => i.Price);
                this.ViewData["totalCost"] = $"{totalPrice:F2}";
            }
            return FileViewResponse("shopping/cart");
        }
    }
}

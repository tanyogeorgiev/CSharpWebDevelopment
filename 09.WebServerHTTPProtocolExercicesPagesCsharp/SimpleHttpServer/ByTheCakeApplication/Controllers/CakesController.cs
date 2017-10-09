using SampleHttpServer.Server.Http.Contracts;
using SimpleHttpServer.ByTheCakeApplication.Data;
using SimpleHttpServer.ByTheCakeApplication.Infrastructures;
using SimpleHttpServer.ByTheCakeApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SimpleHttpServer.ByTheCakeApplication.Controllers
{
    public class CakesController : Controller
    {
        private readonly CakesData cakesData;
        public CakesController()
        {
            this.cakesData = new CakesData();
        }
        public IHttpResponse Add()
        {
            this.ViewData["showBox"] = "none";
            return this.FileViewResponse("cakes/add");
        }



        public IHttpResponse Add(string name, string price)
        {
            var cake = new Cake
            {
                Name = name,
                Price = decimal.Parse(price)
            };
            


            this.cakesData.Add(name, price);
            this.ViewData["name"] = name;
            this.ViewData["price"] = price;
            this.ViewData["showBox"] = "block";

            return this.FileViewResponse("cakes/add");
        }

        public IHttpResponse Search(IHttpRequest req)
        {
            var urlParameters = req.UrlParameters;

            const string searchTerm = "searchTerm";

           this.ViewData["results"] = string.Empty;

            this.ViewData["searchTerm"] = string.Empty;

            if (urlParameters.ContainsKey(searchTerm))
            {

                var searchTermParameter = urlParameters[searchTerm];

                this.ViewData["searchTerm"] = searchTermParameter;


                var savedCakes = this.cakesData.All()
                    .Where(c => c.Name.ToLower().Contains(searchTermParameter.ToLower()))
                    .Select(c => $"<li> {c.Name} - ${c.Price:F2} <a href=\"/shopping/add/{c.Id}?searchTerm={searchTermParameter}\"> Order </a></li>");

                var results = "No Cakes found";
                    if(savedCakes.Any())
                {
                     results = string.Join(Environment.NewLine, savedCakes);

                }
                this.ViewData["results"] = results;

            }
            else
            {
                this.ViewData["results"] = "Please enter search term";
            }
            this.ViewData["showCart"] = "none";


            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);
            if (shoppingCart.Orders.Any())
            {
                var totalProducts = shoppingCart.Orders.Count;
                var totalProductsText = totalProducts != 1 ? "products" : "product";

                this.ViewData["showCart"] = "block";
                this.ViewData["products"] = $"{totalProducts} {totalProductsText}";
            }
          

            return this.FileViewResponse("cakes/search");
        }



    }
}

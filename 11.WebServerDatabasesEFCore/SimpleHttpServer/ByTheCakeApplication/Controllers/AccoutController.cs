
namespace SimpleHttpServer.ByTheCakeApplication.Controllers
{
    using SampleHttpServer.Server.Http;
    using SampleHttpServer.Server.Http.Contracts;
    using SampleHttpServer.Server.Http.Response;
    using SimpleHttpServer.ByTheCakeApplication.Infrastructures;
    using SimpleHttpServer.ByTheCakeApplication.Models;
    using SimpleHttpServer.Server.Http.Response;
    using System.Collections.Generic;
    using System;

    public class AccoutController : Controller
    {
        public IHttpResponse Login()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["autShow"] = "none";
            this.ViewData["username"] = "Guest";
            return this.FileViewResponse("account/login");
        }


        public IHttpResponse Login(IHttpRequest req)
        {
            const string formNameKey = "name";
            const string formPasswordKey = "password";

            if (!req.FormData.ContainsKey(formNameKey) || !req.FormData.ContainsKey(formPasswordKey))
            {
                return new BadRequestResponse();
            };
            var name = req.FormData[formNameKey];
            var password = req.FormData[formPasswordKey];

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {

                this.ViewData["error"] = "You have empty fields";
                this.ViewData["showError"] = "block";

                return this.FileViewResponse("account/login");
            };
            req.Session.Add(SessionStore.CurrentUserKey, name);
          
            this.ViewData["username"] = name;
            req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());

            return this.FileViewResponse("home/index");
           // return new RedirectResponse("/");

        }

        internal IHttpResponse Logout(IHttpRequest req)
        {
            req.Session.Clear();
             return new RedirectResponse("/login");
        }
    }
}

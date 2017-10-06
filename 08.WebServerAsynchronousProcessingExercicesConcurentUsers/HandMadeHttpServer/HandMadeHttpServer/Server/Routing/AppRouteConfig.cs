using HandMadeHttpServer.Server.Routing.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using HandMadeHttpServer.Server.Enums;
using HandMadeHttpServer.Server.Handlers;
using System.Linq;

namespace HandMadeHttpServer.Server.Routing
{
    public class AppRouteConfig : IAppRouteConfig
    {
        private readonly Dictionary<HttpRequestmethod, IDictionary<string, RequestHandler>> routes;

        public AppRouteConfig()
        {
            this.routes = new Dictionary<HttpRequestmethod, IDictionary<string, RequestHandler>>();


            var availableMethods = Enum.GetValues(typeof(HttpRequestmethod)).Cast<HttpRequestmethod>();

            foreach (var method in availableMethods)
            {
                this.routes[method] = new Dictionary<string, RequestHandler>();
            }
        }
        public IReadOnlyDictionary<HttpRequestmethod, IDictionary<string, RequestHandler>> Routes => this.routes;


        public void AddRoute(string route, RequestHandler handler)
        {
            var handlerName = handler.GetType().Name.ToLower();
            if (handlerName.Contains("get"))
            {
                this.routes[HttpRequestmethod.GET].Add(route, handler);

            }
            else if(handlerName.Contains("post"))
            {
                this.routes[HttpRequestmethod.POST].Add(route, handler);
            }

            else
            {
                throw new InvalidOperationException("Ivalid handler");
            }
        }


    }
}

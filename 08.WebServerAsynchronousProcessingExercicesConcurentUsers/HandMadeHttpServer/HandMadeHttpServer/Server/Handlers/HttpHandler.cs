using HandMadeHttpServer.Server.Handlers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using HandMadeHttpServer.Server.HTTP.Contracts;
using HandMadeHttpServer.Server.Routing.Contracts;
using System.Text.RegularExpressions;
using HandMadeHttpServer.Server.HTTP.Response;

namespace HandMadeHttpServer.Server.Handlers
{
    public class HttpHandler : IRequestHandler
    {
        private readonly IServerRouteConfig serverRouteConfig;
        public HttpHandler (IServerRouteConfig routeConfig)
        {
            this.serverRouteConfig = routeConfig;

        }
        public IHttpResponse Handle(IHttpContext context)
        {
            var requestMethod = context.Request.RequestMethod;
            var requestPath = context.Request.Path;
            var registredRoutes = this.serverRouteConfig.Routes[requestMethod];

            foreach (var registredRoute in registredRoutes)
            {
                var routePattern = registredRoute.Key;
                var routingContext = registredRoute.Value;

                var routeRegex = new Regex(routePattern);
                var match = routeRegex.Match(requestPath);

                if (match.Success)
                {
                    continue;
                }

                var parameters = routingContext.Parameters;

                foreach (var parameter  in parameters)
                {
                    var parameterValue = match.Groups[parameter].Value;

                    context.Request.AddUrlParameter(parameter, parameterValue);
                }

                return routingContext.Handler.Handle(context);
            }

            return new NotFoundResponse();

           
        }
    }
}

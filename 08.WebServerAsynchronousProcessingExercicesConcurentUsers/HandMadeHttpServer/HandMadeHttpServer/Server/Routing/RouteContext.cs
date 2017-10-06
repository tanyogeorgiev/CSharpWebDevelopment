
namespace HandMadeHttpServer.Server.Routing
{
    using HandMadeHttpServer.Server.Routing.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using HandMadeHttpServer.Server.Handlers;
    using HandMadeHttpServer.Server.Common;

    public class RouteContext : IRoutingContext
    {
        public RouteContext(RequestHandler handler, IEnumerable<string> parameters)
        {
            CoreValidator.ThrowIfNull(handler, nameof(handler));
            CoreValidator.ThrowIfNull(parameters, nameof(parameters));

            this.Handler = handler;
            this.Parameters = parameters;
        }
        public IEnumerable<string> Parameters { get; private set; }

        public RequestHandler Handler { get; private set; }
    }
}

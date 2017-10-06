

namespace HandMadeHttpServer.Server.Routing.Contracts
{
    using HandMadeHttpServer.Server.Enums;
    using HandMadeHttpServer.Server.Handlers;
    using System.Collections.Generic;

    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestmethod, IDictionary<string,RequestHandler>> Routes { get; }

        void AddRoute(string route, RequestHandler handler);
    }
}

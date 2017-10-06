
namespace HandMadeHttpServer.Server.Routing.Contracts
{
    using HandMadeHttpServer.Server.Enums;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IServerRouteConfig
    {
        IDictionary<HttpRequestmethod, IDictionary<string,IRoutingContext>> Routes { get; }
    }
}

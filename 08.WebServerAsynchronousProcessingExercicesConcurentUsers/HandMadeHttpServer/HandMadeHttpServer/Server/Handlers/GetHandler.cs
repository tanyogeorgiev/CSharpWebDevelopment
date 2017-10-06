
namespace HandMadeHttpServer.Server.Handlers
{
    using System;
    using Server.HTTP.Contracts;

    public class GetHandler : RequestHandler
    {
        protected GetHandler(Func<IHttpRequest, IHttpResponse> handlingFunc) : base(handlingFunc)
        {
        }
    }
}

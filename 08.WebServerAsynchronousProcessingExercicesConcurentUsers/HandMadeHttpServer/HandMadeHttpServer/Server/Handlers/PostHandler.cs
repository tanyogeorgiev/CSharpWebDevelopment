
namespace HandMadeHttpServer.Server.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using HTTP.Contracts;

    public class PostHandler : RequestHandler

    {
        protected PostHandler(Func<IHttpRequest, IHttpResponse> handlingFunc) : base(handlingFunc)
        {
        }
    }
}

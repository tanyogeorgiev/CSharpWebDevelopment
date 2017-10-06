

namespace HandMadeHttpServer.Server.Handlers
{
    using Contracts;
    using Server.Common;
    using Server.HTTP;
    using Server.HTTP.Contracts;
    using System;


    public abstract class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpRequest, IHttpResponse> handlingFunc;

        
        protected RequestHandler (Func<IHttpRequest, IHttpResponse> handlingFunc)
        {
            CoreValidator.ThrowIfNull(handlingFunc, nameof(handlingFunc));
            this.handlingFunc = handlingFunc;
        }

        public IHttpResponse Handle (IHttpContext context)
        {
            var response = this.handlingFunc(context.Request);

            response.HeaderCollection.Add(new HttpHeader("Content-Type", "text/plain"));

            return response;
        }

    }

}



namespace HandMadeHttpServer.Server.HTTP
{
    using Contracts;
    using HandMadeHttpServer.Server.Common;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HttpContext : IHttpContext

    {
        private readonly IHttpRequest request;

        public HttpContext(IHttpRequest request)
        {
            CoreValidator.ThrowIfNull(request, nameof(request));
            this.request = request;
           
        }

        
    }
}

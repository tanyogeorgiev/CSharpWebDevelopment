

namespace HandMadeHttpServer.Server.HTTP.Contracts
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using System.Text;
    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; }
        HttpHeaderCollection HeaderCollection { get; }

    }
}

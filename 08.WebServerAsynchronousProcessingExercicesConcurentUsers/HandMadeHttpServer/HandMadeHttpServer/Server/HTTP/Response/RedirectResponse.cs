
namespace HandMadeHttpServer.Server.HTTP.Response
{
    using Server.Common;
    using Server.Enums;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RedirectResponse : HttpResponse
    {
        protected RedirectResponse(string redirectUrl) 
        {
            CoreValidator.ThrowIfNullOrEmpty(redirectUrl, nameof(redirectUrl));
            this.StatusCode = HttpStatusCode.Found;
            this.HeaderCollection.Add(new HttpHeader("Location", redirectUrl));
        }
    }
}

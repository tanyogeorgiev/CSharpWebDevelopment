
namespace HandMadeHttpServer.Server.HTTP.Response
{
    using Contracts;
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Server.Contracts;
    using HandMadeHttpServer.Server.Exceptions;

    public class ViewResponse : HttpResponse
    {
        private readonly IView view;

        protected ViewResponse(HttpStatusCode statusCode, IView view)
        {
            this.ValidateStatusCode(statusCode);

            this.view = view;
            this.StatusCode = statusCode;
        }

        private void ValidateStatusCode(HttpStatusCode statusCode)
        {
            var statusCodeNumber = (int)StatusCode;

             if (299< statusCodeNumber && statusCodeNumber < 400)
            {
                throw new InvalidResponseException("View responses need a status code below 300 and above 400 (inclusive).");
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}{this.view.View()}";
        }
    }
}

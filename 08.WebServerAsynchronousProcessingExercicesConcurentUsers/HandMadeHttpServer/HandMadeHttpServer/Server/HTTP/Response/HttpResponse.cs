

namespace HandMadeHttpServer.Server.HTTP.Response
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Server.Contracts;
    using Enums;
    using HandMadeHttpServer.Server.Common;
    using HandMadeHttpServer.Server.HTTP.Contracts;

    public abstract class HttpResponse: IHttpResponse
    {
      
        private string statusMessage => this.StatusCode.ToString();

        protected HttpResponse()
        {
            this.HeaderCollection = new HttpHeaderCollection();
        }

        
        public HttpHeaderCollection HeaderCollection { get; set; }
        public HttpStatusCode StatusCode { get; protected set; }


        public override string ToString()
        {
            var response = new StringBuilder();
            var statusCodeNumber = (int)this.StatusCode;
            response.AppendLine($"HTTP/1.1 {statusCodeNumber} {this.statusMessage}");
            response.AppendLine(this.HeaderCollection.ToString());
            response.AppendLine();



            return response.ToString();
        }
    }
}

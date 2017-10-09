using SampleHttpServer.Server.Enums;
using SampleHttpServer.Server.Http.Response;
using SimpleHttpServer.Server.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleHttpServer.Server.Http.Response
{
    public class InternalServerErrorResponse : ViewResponse
    {
        public InternalServerErrorResponse(Exception err) : base (HttpStatusCode.InternalServerError, new InternalServerErrorView(err))
        {
          
        }
      
    }
}

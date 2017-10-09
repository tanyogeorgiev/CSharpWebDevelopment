

using SampleHttpServer.Server.Enums;
using SampleHttpServer.Server.Http.Response;

namespace SimpleHttpServer.Server.Http.Response
{
  public  class BadRequestResponse : HttpResponse
    {
        public BadRequestResponse()
        {
            this.StatusCode = HttpStatusCode.BadRequest;
        }
    }
}

namespace SampleHttpServer.Server.Http.Response
{
    using Enums;
    using SimpleHttpServer.Server.Common;

    public class NotFoundResponse : ViewResponse
    {
        public NotFoundResponse() : base(HttpStatusCode.NotFound,new NotFoundView())
        {
          
        }
    }
}


namespace SimpleHttpServer.ByTheCakeApplication.Controllers
{
    using SampleHttpServer.Server.Enums;
    using SampleHttpServer.Server.Http.Contracts;
    using SampleHttpServer.Server.Http.Response;
    using SimpleHttpServer.ByTheCakeApplication.Infrastructures;
    using SimpleHttpServer.ByTheCakeApplication.Views.Home;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class HomeController : Controller
    {
        public IHttpResponse Index() => this.FileViewResponse("home/index");

        public IHttpResponse About() => this.FileViewResponse("home/about");
        
    }
}

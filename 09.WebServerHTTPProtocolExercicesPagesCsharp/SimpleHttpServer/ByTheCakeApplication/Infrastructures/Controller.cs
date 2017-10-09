
namespace SimpleHttpServer.ByTheCakeApplication.Infrastructures
{
    using SampleHttpServer.Server.Enums;
    using SampleHttpServer.Server.Http.Contracts;
    using SampleHttpServer.Server.Http.Response;
    using SimpleHttpServer.ByTheCakeApplication.Views.Home;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public abstract class Controller
    {

        public const string DefaultPath = @"./ByTheCakeApplication/Resources/{0}.html";
        public const string ContentPlaceHolder = "{{{content}}}";

     

        public Controller()
        {
            this.ViewData = new Dictionary<string, string>();
            this.ViewData["autShow"] = "block";
            
        }
        
        public IHttpResponse FileViewResponse(string fileName )
        {
            var result = this.ProcessFileHtml(fileName);
          
            if ( this.ViewData.Any())
            {
                foreach (var value in ViewData)
                {
                    result = result.Replace($"{{{{{{{value.Key}}}}}}}", value.Value);
                }    
            }
           

            return new ViewResponse(HttpStatusCode.Ok, new FileView(result));
        }

        protected IDictionary<string, string> ViewData { get; private set; }

        private string ProcessFileHtml(string fileName)
        {
            var layoutHtml = File.ReadAllText(string.Format(DefaultPath, "layout"));
            var fileHtml = File.ReadAllText(string.Format(DefaultPath, fileName));

            var result = layoutHtml.Replace(ContentPlaceHolder, fileHtml);

            return result;
        }
    }
}

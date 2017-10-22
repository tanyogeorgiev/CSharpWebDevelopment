

namespace SimpleHttpServer.ByTheCakeApplication.Views.Home
{
    using SampleHttpServer.Server.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    class FileView : IView
    {
        private readonly string htmlFile;
        public FileView(string htmlFile)
        {
            this.htmlFile = htmlFile;
                
        }
        public string View()
        {
            return this.htmlFile;
        }
    }
}

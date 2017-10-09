using SampleHttpServer.Server.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleHttpServer.Server.Common
{

     
    public class InternalServerErrorView : IView
    {
        private readonly Exception exception;

        public InternalServerErrorView(Exception ex)
        {
            this.exception = ex;
        }
        public string View()
        {
            return $"<h1>Server Error</h1></br><hr/><p>{this.exception.Message}<p>";
        }
    }
}

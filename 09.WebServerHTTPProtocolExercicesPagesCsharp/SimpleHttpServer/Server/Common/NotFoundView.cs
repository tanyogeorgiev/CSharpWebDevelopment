using SampleHttpServer.Server.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleHttpServer.Server.Common
{
    class NotFoundView : IView
    {
        public string View()
        {
            return $"<h1>404 The Page is Too High to response.... Try later..</h1>";
        }
    }
}

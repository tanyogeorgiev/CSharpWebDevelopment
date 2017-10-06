using System;
using System.Collections.Generic;
using System.Text;

namespace HandMadeHttpServer.Server.HTTP.Contracts
{
  public class IHttpContext
    {
      public  IHttpRequest Request { get; }
    }
}

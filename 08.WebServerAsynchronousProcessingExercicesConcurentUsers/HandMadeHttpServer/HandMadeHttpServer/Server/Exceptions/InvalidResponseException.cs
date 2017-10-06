
namespace HandMadeHttpServer.Server.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class InvalidResponseException : Exception
    {
        public InvalidResponseException(string message)
            :base (message)
        {

        }

    }
}

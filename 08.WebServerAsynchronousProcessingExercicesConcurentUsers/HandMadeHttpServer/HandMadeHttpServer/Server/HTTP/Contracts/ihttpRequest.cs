﻿using HandMadeHttpServer.Server.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HandMadeHttpServer.Server.HTTP.Contracts
{
    public interface IHttpRequest
    {
        Dictionary<string, string> FormData { get; }

        HttpHeaderCollection HeaderCollection { get; }

        string Path { get; }

        Dictionary<string, string> QueryParameters { get; }

        HttpRequestmethod RequestMethod { get; }

        string Url { get; }

        Dictionary<string, string> UrlParameters { get; }

        void AddUrlParameter(string key, string value);

    }
}

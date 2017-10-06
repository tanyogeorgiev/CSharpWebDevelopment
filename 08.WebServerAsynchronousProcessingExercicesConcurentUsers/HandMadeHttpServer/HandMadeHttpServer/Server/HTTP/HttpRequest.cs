

namespace HandMadeHttpServer.Server.HTTP
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using Enums;
    using Common;
    using System.Linq;
    using Exceptions;
    using System.Net;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));
            this.FormData = new Dictionary<string, string>();
            this.HeaderCollection = new HttpHeaderCollection();
            this.QueryParameters = new Dictionary<string, string>();
            this.UrlParameters = new Dictionary<string, string>();

            this.ParseRequest(requestString);
        }



        public Dictionary<string, string> FormData { get; private set; }

        public HttpHeaderCollection HeaderCollection { get; private set; }

        public string Path { get; private set; }

        public Dictionary<string, string> QueryParameters { get; private set; }

        public HttpRequestmethod RequestMethod { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, string> UrlParameters { get; private set; }

        public void AddUrlParameter(string key, string value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.UrlParameters[key] = value;

        }


        private void ParseRequest(string requestString)
        {
            var requestLines = requestString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (requestLines.Any())
            {
                BadRequestException.ThrowFromInvalidRequest();
            }
            var requestLine = requestLines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (requestLine.Length != 3
                || requestLine[2].ToLower() != "http/1.1")
            {
                BadRequestException.ThrowFromInvalidRequest();
            }

            this.Url = requestLine[1];

            this.RequestMethod = this.ParseMethod(requestLine[0]);

            this.Path = this.ParsePath(requestLine[1]);

            this.ParseHeaders(requestLine);

            this.ParseParameters();

            this.ParseFormData(requestLines.Last());

            
        }

    

        private HttpRequestmethod ParseMethod(string method)
        {

            if (!Enum.TryParse(method, true, out HttpRequestmethod parsedMethod))
            {
                BadRequestException.ThrowFromInvalidRequest();

            }
            return parsedMethod;
        }


        private string ParsePath(string requestPath)
        {
            return requestPath.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];
        }

        private void ParseHeaders(string[] requestLine)
        {
            var emptyLineAfterHeadersIndex = Array.IndexOf(requestLine, string.Empty);

            for (int i = 1; i < emptyLineAfterHeadersIndex; i++)
            {
                var currentLine = requestLine[i];
                var headerParts = currentLine.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                if (headerParts.Length != 2)
                {
                    BadRequestException.ThrowFromInvalidRequest();
                }


                this.HeaderCollection.Add(new HttpHeader(headerParts[0], headerParts[1]));


            }

            if (this.HeaderCollection.ContainsKey("Host"))
            {
                BadRequestException.ThrowFromInvalidRequest();
            }
        }

        private void ParseParameters()
        {
          if (!this.Url.Contains('?'))
            {
                return;
            }

            var query = this.Url
                   .Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries)
                   .Last();


            this.ParseQuery(query, this.UrlParameters);
        }

        private void ParseFormData(string formData)
        {
            if (this.RequestMethod == HttpRequestmethod.GET)
            {
                return;
            }
            this.ParseQuery(formData, this.QueryParameters);
        }

        private void ParseQuery(string query,IDictionary<string, string> dict)
        {
           

            if (!query.Contains('='))
            {
                return;
            }

            var queryPairs = query.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var qp in queryPairs)
            {
                var qpKvp = qp.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                if (qpKvp.Length != 2)
                {
                    return;
                }
                var queryKey = WebUtility.UrlDecode(qpKvp[0]);
                var queryValue = WebUtility.UrlDecode(qpKvp[1]);
                dict.Add(queryKey, queryValue);

            }
        }
    }
}


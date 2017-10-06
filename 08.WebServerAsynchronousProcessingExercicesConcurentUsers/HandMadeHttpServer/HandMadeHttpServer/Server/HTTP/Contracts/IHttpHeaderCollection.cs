
namespace HandMadeHttpServer.Server.HTTP.Contracts
{
      public interface IHttpHeaderCollection
    {
        void Add(HttpHeader header);
        bool ContainsKey(string key);
        HttpHeader Get(string key);
    }
}

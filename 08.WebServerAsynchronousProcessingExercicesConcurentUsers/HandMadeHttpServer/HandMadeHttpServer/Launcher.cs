using HandMadeHttpServer.Server;
using HandMadeHttpServer.Server.Contracts;
using HandMadeHttpServer.Server.Routing;
using System;

namespace HandMadeHttpServer
{
    public class Launcher : IRunnable
    {
        private WebServer webServer;

        public static void Main( )
        {
            new Launcher().Run();

        }

        public void Run()
        {
            var appRouteConfig = new AppRouteConfig();
            var webServer = new WebServer(1337, appRouteConfig);

            webServer.Run();
        }
    }
}

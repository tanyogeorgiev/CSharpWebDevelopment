﻿namespace SampleHttpServer
{
    using Application;
    using Server;
    using Server.Contracts;
    using Server.Routing;
    using SimpleHttpServer.ByTheCakeApplication;

    public class Launcher : IRunnable
    {
        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            var mainApplication = new ByTheCakeApp();
            var appRouteConfig = new AppRouteConfig();
            mainApplication.Configure(appRouteConfig);

            var webServer = new WebServer(1337, appRouteConfig);

            webServer.Run();
        }
    }
}

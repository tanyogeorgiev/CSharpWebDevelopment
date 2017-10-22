
namespace SimpleMvc.App
{
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class Launcher
    {
        public static void Main()
        {
            MvcEngine.Run(new WebServer(1338, new ControllerRouter()));
        }
    }
}

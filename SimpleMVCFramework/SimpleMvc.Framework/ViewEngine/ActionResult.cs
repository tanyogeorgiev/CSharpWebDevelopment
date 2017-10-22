
namespace SimpleMvc.Framework.ViewEngine
{
    using Framework.Contracts;
    using System;

    public class ActionResult : IActionResult
    {
        public ActionResult(string viewFullQUalifiedName)
        {
            this.Action = (IRenderable)Activator.CreateInstance(Type.GetType(viewFullQUalifiedName));
        }

        public IRenderable Action { get; set; }

        public string Invoke() => this.Action.Render();
    }
}


namespace SimpleMvc.Framework.ViewEngine.Generic
{
    using SimpleMvc.Framework.Contracts.Generic;
    using System;

    public class ActionResult<TModel> : IActionResult<TModel>
    {
        public ActionResult(string viewFullQUalifiedName, TModel model)
        {
            this.Action = (IRenderable<TModel>)Activator.CreateInstance(Type.GetType(viewFullQUalifiedName));
        }

        public IRenderable<TModel> Action { get; set; }

        public string Invoke() => this.Action.Render();
    }
}

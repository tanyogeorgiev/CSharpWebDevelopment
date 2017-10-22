

namespace SimpleMvc.Framework.Controllers
{
    using Contracts;
    using Contracts.Generic;
    using Helpers;
    using SimpleMvc.Framework.ViewEngine;
    using SimpleMvc.Framework.ViewEngine.Generic;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName]string caller = "")
        {
            var controllerName = ControllerHelpers.GetControllerName(this);

            var viewFullQuilifiedName = ControllerHelpers.GetVeiwFullQualifiedName(controllerName,caller);

            return new ActionResult(viewFullQuilifiedName);
        }

        protected IActionResult View (string controller, string action)
        {

            var viewFullQuilifiedName = ControllerHelpers.GetVeiwFullQualifiedName(controller, action);

            return new ActionResult(viewFullQuilifiedName);

        }

        protected IActionResult<TModel> View <TModel>(TModel model, [CallerMemberName]string caller = "")
        {
            var controllerName = ControllerHelpers.GetControllerName(this);

            var viewFullQuilifiedName = ControllerHelpers.GetVeiwFullQualifiedName(controllerName, caller);

            return new ActionResult<TModel>(viewFullQuilifiedName, model);
        }

        protected IActionResult<TModel> View<TModel> (TModel model,
            string controller,
            string action)
        {
            var viewFullQuilifiedName = ControllerHelpers.GetVeiwFullQualifiedName(controller, action);

            return new ActionResult<TModel>(viewFullQuilifiedName, model);
        }
    }
}

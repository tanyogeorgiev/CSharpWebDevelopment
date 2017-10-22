﻿
namespace SimpleMvc.Framework.Helpers
{
   public static class ControllerHelpers
    {
        public static string GetControllerName(object controler) => controler.GetType()
                .Name
                .Replace(MvcContext.Get.ControllersSuffix, string.Empty);


        public static string GetVeiwFullQualifiedName (
            string controller,
            string action)
            => string.Format("{0}.{1}.{2}.{3}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ViewsFolder,
                controller,
                action);
    }


}


namespace SimpleMvc.App.Controllers
{
    using Framework.Attributes.Methods;
    using Framework.Controllers;
    using App.Models;
    using Framework.Contracts;

    public class HomeController : Controller
    {
        public IActionResult Index(int Id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int Id, IndexModel model)
        {
            return View();
        }

     //   public void Create()
     //   {
     //       //return the form
     //   }
     //
     //   [HttpPost]
     //   public void Create(int id)
     //   {
     //       //saves the form...
     //   }
    }
}

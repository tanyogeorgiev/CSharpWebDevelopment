

namespace GameStore.App.Controllers
{
    using Models;
    using Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class UsersController : BaseController
    {
        private const string RegisterError = @"<li>Email – must contain @ sign and a period.It must be unique.</li>
            <li>Password – length must be at least 6 symbols and must contain at least 1 uppercase, 1 lowercase letter and 1 digit</li>
            <li>Confirm Password – must match the provided password</li>";
        private const string EmailExistError = @"<li> Email is already taken</li>";
        private const string LoginError = @"<li>Invalid credentials</li>";

        private IUserService users;

        
        public UsersController(IUserService users)
        {
            this.users = users;
        }
        

        public IActionResult Register() => this.View();


        [HttpPost]
        public  IActionResult Register(RegisterModel model)
        {
            if(model.Password != model.ConfirmPassword
                || !this.IsValidModel(model))
            {

                this.ShowError(RegisterError);
                return this.View();
            }

            var res = this.users.Create(
                model.Email,
                model.Password,
                model.Name);

            if (res)
            {
                return this.Redirect("/users/login");
            }

            else
            {
                this.ShowError(EmailExistError);
                return this.View();
            }
            
        }



        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {

            if (!this.IsValidModel(model))
            {
                this.ShowError(LoginError);
                return this.View();
            }

            if ( this.users.UserExist(model.Email,model.Password))
            {
                this.SignIn(model.Email);
                return this.Redirect("/");

            }
            else
            {
                this.ShowError(LoginError);
                return this.View();
            }
            
        }

        public IActionResult Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }


    }
}

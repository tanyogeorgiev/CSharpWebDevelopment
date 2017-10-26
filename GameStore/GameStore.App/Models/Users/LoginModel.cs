
namespace GameStore.App.Models
{
    using GameStore.App.Infrastructure.Validations;

    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        public string Password { get; set; }

    }
}


namespace GameStore.App.Models
{
    using Infrastructure.Validations;
    using Infrastructure.Validations.Users;

    public  class RegisterModel
    {
        [Required]
        [Email]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Password]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}

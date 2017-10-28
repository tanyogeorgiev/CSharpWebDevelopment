

namespace GameStore.App.Services
{
    using Contracts;
    using GameStore.App.Data;
    using GameStore.App.Data.Models;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly GameStoreDbContext db;

        public UserService(GameStoreDbContext db)
        {
            this.db = db;
        }

        public bool Create(string email, string password, string name)
        {

            if (this.db.Users.Any(u => u.Email == email))
            {
                return false;
            }

            var isAdmin = !this.db.Users.Any();

            var newUser = new User()
            {
                Email = email,
                Password = password,
                Name = name,
                IsAdmin = isAdmin
            };

            this.db.Add(newUser);
            this.db.SaveChanges();

            return true;

        }
        public bool UserExist(string email, string pasword)
            => this.db
                    .Users
                    .Any(u => u.Email == email && u.Password == pasword);
    }
}



namespace GameStore.App.Services
{
    using Contracts;
    using GameStore.App.Data;
    using GameStore.App.Data.Models;
    using System.Linq;

    public class UserService : IUserService
    {
        public bool Create(string email, string password, string name)
        {
            using (var db = new GameStoreDbContext())
            {
                if (db.Users.Any(u => u.Email == email))
                {
                    return false;
                }

                    var newUser = new User()
                    {
                        Email = email,
                        Password = password,
                        Name = name
                    };

                    db.Add(newUser);
                    db.SaveChanges();

                    return true;
             }
        }
        public bool UserExist(string email, string pasword)
        {
            using (var db = new GameStoreDbContext())
            {
                return db
                    .Users
                    .Any(u => u.Email == email && u.Password == pasword);

            }

        }

    }
}

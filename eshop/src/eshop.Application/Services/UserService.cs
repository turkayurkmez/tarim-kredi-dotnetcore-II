using eshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Services
{
    public class UserService : IUserService
    {
        private List<User> _users = new()
        {
             new(){ Id = 1, Username = "turkay", Password = "1234", Role="admin", Email = "a@b.com"},
             new(){ Id = 2, Username = "user1", Password = "1234", Role="client", Email = "b@b.com"},
             new(){ Id = 2, Username = "user2", Password = "1234", Role="editor", Email = "x@y.com"}


        };
        public User? ValidateUser(string username, string password)
        {
            return _users.SingleOrDefault(x => x.Username == username && x.Password == password);

        }
    }
}

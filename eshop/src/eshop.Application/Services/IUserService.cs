using eshop.Domain;

namespace eshop.Application.Services
{
    public interface IUserService
    {
        User? ValidateUser(string username, string password);
    }
}
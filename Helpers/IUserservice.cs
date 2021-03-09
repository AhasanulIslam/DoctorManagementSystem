using System.Threading.Tasks;
using DoctorManagement.Models;

namespace DoctorManagement.Helpers
{
    public interface IUserservice
    {
        Task<Users> Register( Users user, string password);
        
        Task<Users> Authenticate(string username, string password);

        Task<bool> UserExist(string username);
    }
}
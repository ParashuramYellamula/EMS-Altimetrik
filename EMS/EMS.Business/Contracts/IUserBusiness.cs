using EMS.Models;
using System.Threading.Tasks;

namespace EMS.Business.Contracts
{
    public interface IUserBusiness
    {
        Task<bool> AddUser(User user);
        Task<TokenModel> ValidateUser(User user);
    }
}

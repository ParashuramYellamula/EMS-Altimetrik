using EMS.DataAccess.DataBaseModels;
using System.Threading.Tasks;

namespace EMS.DataAccess.Contracts
{
    public interface IUserDataAccess
    {
        Task<bool> ValidateUser(User user);
        Task<bool> AddUser(User user);
    }
}

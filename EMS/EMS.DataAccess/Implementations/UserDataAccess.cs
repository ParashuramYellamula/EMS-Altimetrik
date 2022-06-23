using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EMS.DataAccess.Contracts;
using EMS.DataAccess.DataBaseModels;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.DataAccess.Implementations
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly EMSContext _emsContext;
        public UserDataAccess(EMSContext emsContext)
        {
            _emsContext = emsContext;
        }

        public async Task<bool> AddUser(User user)
        {
            if(!_emsContext.Users.Any(x => x.Name == user.Name))
            {
                await _emsContext.Users.AddAsync(user);
                _emsContext.SaveChanges();
                return true;
            }
            return false;
        }

       

        public async Task<bool> ValidateUser(User user)
        {
            var response = await _emsContext.Users.AsNoTracking()
                                                        .Where(u => u.Name == user.Name)
                                                        .FirstOrDefaultAsync();
            if (response != null)
            {
                var passwordVerificationResult = new PasswordHasher<object?>().VerifyHashedPassword(null, response.Password, user.Password);
                return passwordVerificationResult == PasswordVerificationResult.Success;
            }
            return false;
        }

       
    }
}

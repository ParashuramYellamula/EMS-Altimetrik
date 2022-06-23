using Microsoft.AspNetCore.Identity;
using EMS.Business.Contracts;
using EMS.DataAccess.Contracts;
using EMS.Models;
using System.Threading.Tasks;

namespace EMS.Business.Implementations
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserDataAccess _userDataAccess;
        private readonly ITokenBusiness _tokenBusiness;
        public UserBusiness(IUserDataAccess userDataAccess, ITokenBusiness tokenBusiness)
        {
            _userDataAccess = userDataAccess;
            _tokenBusiness = tokenBusiness;
        }

        public async Task<bool> AddUser(User user)
        {
            DataAccess.DataBaseModels.User dataAccessUser = AutoMappingProfiler.ConvertBusinessUserToDataAccessUser(user);
            dataAccessUser.Password = new PasswordHasher<object?>().HashPassword(null, user.Password);
            return await _userDataAccess.AddUser(dataAccessUser);
        }

        public async Task<TokenModel> ValidateUser(User user)
        {           
            DataAccess.DataBaseModels.User dataAccessUser = AutoMappingProfiler.ConvertBusinessUserToDataAccessUser(user);
            TokenModel tokenModel = new TokenModel();
            bool isValidUser = await _userDataAccess.ValidateUser(dataAccessUser);
            if (isValidUser)
            {
                tokenModel = _tokenBusiness.GenerateTokens(user);
            }
            else
            {
                tokenModel = null;
            }
            return tokenModel;
        }
    }
}

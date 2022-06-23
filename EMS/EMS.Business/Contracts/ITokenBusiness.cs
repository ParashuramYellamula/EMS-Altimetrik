using EMS.Models;

namespace EMS.Business.Contracts
{
    public interface ITokenBusiness
    {
        TokenModel GenerateTokens(User user);
    }
}

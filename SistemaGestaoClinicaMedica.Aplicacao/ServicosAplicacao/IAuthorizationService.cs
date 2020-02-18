using System.Threading.Tasks;

namespace Api.PoC.Auth
{
    public interface IAuthorizationService
    {
        Task<BaseResult<IUser>> AuthorizeAsync(LoginUser loginUser);
    }
}
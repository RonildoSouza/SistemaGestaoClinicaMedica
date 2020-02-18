using System;
using System.Threading.Tasks;

namespace Api.PoC.Auth
{
    public sealed class AuthorizationService : IAuthorizationService
    {
        public async Task<BaseResult<IUser>> AuthorizeAsync(LoginEntradaDTO loginUser)
        {
            var loginOrEmail = loginUser?.Email ?? "";
            var password = loginUser?.Senha ?? "";

            var result = new BaseResult<IUser>();

            if (loginOrEmail == "rns" && password == "123")
            {
                result.Success = true;
                result.Message = "User authorized!";
                result.Data = new MyLoggedUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Name test",
                    Credentials = "01|02|09",
                    IsAdmin = false
                };
            }
            else
            {
                result.Success = false;
                result.Message = "Not authorized!";
            }

            return await Task.FromResult(result);
        }
    }
}

namespace Api.PoC.Auth
{
    public interface ILoggedUserService
    {
        BaseResult<T> GetLoggedUser<T>() where T : class, IUser;
    }
}
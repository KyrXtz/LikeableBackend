namespace SharedKernel.Interfaces
{
    public interface IIdentityService
    {
        Task<Result<LoginUserResponseModel>> Login(string userId, string username, string secret, string role);

        Task<Result<RegisterUserResponseModel>> Register(string username, string password, string email);
    }
}

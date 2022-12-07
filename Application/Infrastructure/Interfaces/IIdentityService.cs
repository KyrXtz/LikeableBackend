namespace Application.Infrastructure.Services
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string userId, string username, string secret, string role);
    }
}

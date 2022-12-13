namespace SharedKernel.Interfaces
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string userId, string username, string secret, string role);
    }
}

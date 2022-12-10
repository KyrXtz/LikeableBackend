namespace Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal user;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            user = httpContextAccessor.HttpContext?.User;
        }

        public string GetId()
        {
            var id = user?.GetId();

            return id ?? string.Empty;
        }

        public string GetUserName()
        {
            var username = user?.Identity?.Name;

            return username ?? string.Empty;
        }
    }
}

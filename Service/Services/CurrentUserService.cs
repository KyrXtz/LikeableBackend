using Microsoft.AspNetCore.Http;
using SharedKernel.Models.Response.User;

namespace Service.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result<GetCurrentUserIdResponseModel>> GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext?.User?.GetId();
            if (userId == null) return "Current User not found ??";

            return new GetCurrentUserIdResponseModel
            {
                UserId = userId
            };
        }
    }
}

using SharedKernel.Models.Response.User;

namespace Application.Queries.User
{
    #region Query
    public class LikedItemsQuery : BaseQuery, IRequest<Result<LikedItemsResponseModel>>
    {
        public LikedItemsQuery()
        {
        }
    }
    #endregion
    #region Validation
    public class LikedItemsQueryValidator : AbstractValidator<LikedItemsQuery>
    {
        public LikedItemsQueryValidator()
        {
        }
    }
    #endregion
    #region Handler
    public class LikedItemsQueryHandler : IRequestHandler<LikedItemsQuery, Result<LikedItemsResponseModel>>
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        public LikedItemsQueryHandler(IUserService userService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
        }

        public async Task<Result<LikedItemsResponseModel>> Handle(LikedItemsQuery request, CancellationToken cancellationToken)
        {
            var userRes = await _currentUserService.GetCurrentUserId();
            if (!userRes.Succeeded) return userRes.Error;
            var userId = userRes.Data.UserId;

            var res = await _userService.LikedItems(userId);
            if (!res.Succeeded) return res.Error;

            return res;
        }
    }
    #endregion

}

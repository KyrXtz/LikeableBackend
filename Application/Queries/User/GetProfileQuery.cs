using SharedKernel.Models.Response.User;

namespace Application.Queries.User
{
    #region Query
    public class GetProfileQuery : BaseQuery, IRequest<Result<GetProfileResponseModel>>
    {
        public string UserId { get; set; }

        public GetProfileQuery(string userId)
        {
            UserId = userId;
        }
    }
    #endregion
    #region Validation
    public class GetProfileQueryValidator : AbstractValidator<GetProfileQuery>
    {
        public GetProfileQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull();
        }
    }
    #endregion
    #region Handler
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, Result<GetProfileResponseModel>>
    {
        private readonly IUserService _userService;

        public GetProfileQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result<GetProfileResponseModel>> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var res = await _userService.GetProfile(request.UserId);
            if (!res.Succeeded) return res.Error;

            return res;
        }
    }
    #endregion

}

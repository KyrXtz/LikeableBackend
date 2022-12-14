namespace Application.Queries.Items
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
        private readonly IProfileService _profileService;

        public GetProfileQueryHandler(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public async Task<Result<GetProfileResponseModel>> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var res = await _profileService.ByUser(request.UserId);
            if (!res.Succeeded) return res.Error;

            return res;
        }
    }
    #endregion

}

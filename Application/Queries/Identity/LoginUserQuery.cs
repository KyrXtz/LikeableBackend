namespace Application.Queries.Identity
{
    #region Query
    public class LoginUserQuery : BaseQuery, IRequest<Result<LoginUserResponseModel>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }


        public LoginUserQuery(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
    #endregion
    #region Validation
    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().NotNull();
            RuleFor(x => x.Password).NotEmpty().NotNull();
        }
    }
    #endregion
    #region Handler
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, Result<LoginUserResponseModel>>
    {
        private readonly IIdentityService _identityService;
        private readonly UserManager<Domain.Aggregates.User> _userManager;
        private readonly ApplicationSettings _appSettings;

        public LoginUserQueryHandler(IIdentityService identityService, UserManager<Domain.Aggregates.User> userManager, IOptions<ApplicationSettings> appSettings)
        {
            _identityService = identityService;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        public async Task<Result<LoginUserResponseModel>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return "User not exists";

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid) return "Invalid password";

            var role = await _userManager.GetRolesAsync(user);
            var res = await _identityService.Login(user.Id, user.UserName, _appSettings.Secret, role.First());

            if (!res.Succeeded) return res.Error;

            return res;
        }
    }
    #endregion

}

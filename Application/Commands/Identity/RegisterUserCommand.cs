using Microsoft.AspNetCore.Identity;

namespace Application.Commands.Identity
{
    #region Command
    public class RegisterUserCommand : BaseCommand, IRequest<Result<RegisterUserResponseModel>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public RegisterUserCommand(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
        }
    }
    #endregion
    #region Validation
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator(IOptions<ValidationSettings> options)
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
        }
    }
    #endregion
    #region Handler
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<RegisterUserResponseModel>>
    {
        private readonly IIdentityService _identityService;

        public RegisterUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Result<RegisterUserResponseModel>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var res = await _identityService.Register(request.UserName, request.Password, request.Email);
            if (!res.Succeeded) return res.Error;

            return res;
        }
    }
    #endregion

}

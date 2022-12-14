namespace Application.Commands.Profiles
{
    #region Command
    public class UpdateProfileCommand : BaseCommand, IRequest<Result<UpdateProfileResponseModel>>
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string MainPhotoUrl { get; set; }


        public UpdateProfileCommand(string userId, string username, string name, string mainPhotoUrl)
        {         
            UserId = userId;
            UserName = username;
            Name = name;
            MainPhotoUrl = mainPhotoUrl;
        }
    }
    #endregion
    #region Validation
    public class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommand>
    {
        public UpdateProfileCommandValidator(IOptions<ValidationSettings> options)
        {
            //RuleFor(x => x.UserId).NotNull().NotEmpty();
            //RuleFor(x => x.MainPhotoUrl).NotNull().NotEmpty();
            //RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Name.Length).LessThanOrEqualTo(Convert.ToInt32(options.Value.MaxNameLength));
        }
    }
    #endregion
    #region Handler
    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, Result<UpdateProfileResponseModel>>
    {
        private readonly IProfileService _ProfilesService;

        public UpdateProfileCommandHandler(IProfileService ProfilesService)
        {
            _ProfilesService = ProfilesService;
        }

        public async Task<Result<UpdateProfileResponseModel>> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name) && string.IsNullOrEmpty(request.MainPhotoUrl) && string.IsNullOrEmpty(request.UserName)) 
                return "No data to be updated.";
            
            var res = await _ProfilesService.UpdateUserName(
                request.UserId,
                request.UserName);
            if (!res.Succeeded) return res.Error;

            res = await _ProfilesService.UpdateProfile(
                request.UserId,
                request.Name,
                request.MainPhotoUrl);
            if (!res.Succeeded) return res.Error;

            return res;
        }
    }
    #endregion

}

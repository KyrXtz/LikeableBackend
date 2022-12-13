using Domain.Aggregates;
using SharedKernel.Interfaces;

namespace Api.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class IdentityController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationSettings _appSettings;
        private readonly IIdentityService _identityService;

        public IdentityController(UserManager<User> userManager,
            IOptions<ApplicationSettings> appSettings,
            IIdentityService identityService)
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _identityService = identityService;
        }
        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            var user = Domain.Aggregates.User.Create(null, model.UserName, model.Email); //TODO set profile
            //var user = 
            //{
            //    Email = model.Email,
            //    UserName = model.UserName,
            //};

            var result = await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, Constants.Roles.User.ToString());
            if (!result.Succeeded) return BadRequest(result.Errors);
            else return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null) return Unauthorized();

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!isPasswordValid) return Unauthorized();

            var role = await _userManager.GetRolesAsync(user);

            var token = _identityService.GenerateJwtToken(user.Id, user.UserName, _appSettings.Secret, role.FirstOrDefault());

            return new LoginResponseModel
            {
                Token = token
            };
        }
    }
}

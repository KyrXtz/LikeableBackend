namespace Api.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class IdentityController : BaseController
    {
        public IdentityController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Register))]
        public async Task<ActionResult<RegisterUserResponseModel>> Register(RegisterUserRequestModel model)
        {
            var res = await _mediator.Send(new RegisterUserCommand(model.UserName, model.Password, model.Email));

            if (res.Succeeded) return Ok(res.Data);
            else return BadRequest(res.Error);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginUserResponseModel>> Login(LoginUserRequestModel model)
        {
            var res = await _mediator.Send(new LoginUserQuery(model.UserName, model.Password));

            if (res.Succeeded) return Ok(res.Data);
            else return BadRequest(res.Error);
        }
    }
}

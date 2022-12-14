namespace Api.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class ProfilesController : BaseController
    {
        public ProfilesController(IMediator mediator) :base(mediator)
        {
        }

        [HttpGet]
        [Route(Constants.WebConstants.UserId)]
        public async Task<ActionResult<GetProfileResponseModel>> Mine([FromRoute] string userId,
            [FromQuery] GetProfileRequestModel model) 
        {
            var res = await _mediator.Send(new GetProfileQuery(userId));

            if (res.Succeeded) return Ok(res.Data);
            else return BadRequest(res.Error);
        }

        [HttpPut]
        [Route(Constants.WebConstants.UserId)]
        public async Task<ActionResult<UpdateProfileResponseModel>> Update([FromRoute] string userId, 
            [FromBody] UpdateProfileRequestModel model)
        {
            var res = await _mediator.Send(new UpdateProfileCommand(userId, model.UserName, model.Name, model.MainPhotoUrl));

            if (res.Succeeded) return Ok(res.Data);
            else return BadRequest(res.Error);
        }
    }
}

using SharedKernel.Models.Request.User;
using SharedKernel.Models.Response.User;

namespace Api.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator): base(mediator) { }

        [HttpGet]
        [Route(Constants.WebConstants.GetLikedItems)]
        public async Task<ActionResult<LikedItemsResponseModel>> LikedItems([FromQuery] LikedItemsRequestModel model)
        {
            var res = await _mediator.Send(new LikedItemsQuery());

            if (res.Succeeded) return Ok(res.Data);
            else return BadRequest(res.Error);
        }

        [HttpGet]
        [Route(Constants.WebConstants.Id)]
        public async Task<ActionResult<GetProfileResponseModel>> GetProfile([FromRoute] string id,
            [FromQuery] GetProfileRequestModel model)
        {
            var res = await _mediator.Send(new GetProfileQuery(id));

            if (res.Succeeded) return Ok(res.Data);
            else return BadRequest(res.Error);
        }

        [HttpPut]
        [Route(Constants.WebConstants.Id)]
        public async Task<ActionResult<UpdateProfileResponseModel>> UpdateProfile([FromRoute] string id,
            [FromBody] UpdateProfileRequestModel model)
        {
            var res = await _mediator.Send(new UpdateProfileCommand(id, model.UserName, model.Name, model.MainPhotoUrl));

            if (res.Succeeded) return Ok(res.Data);
            else return BadRequest(res.Error);
        }
    }
}

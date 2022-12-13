namespace Api.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class ProfilesController : BaseController
    {
        //private readonly IProfileService _profiles;
        //private readonly ICurrentUserService _currentUser;

        public ProfilesController(
            //IProfileService profiles,
            //ICurrentUserService currentUser
            )
        {
            //_profiles = profiles;
            //_currentUser = currentUser;
        }

        [HttpGet]
        public async Task<ActionResult<UpdateProfileResponseModel>> Mine() // TODO change the response model to GetProfileResponseModel
        {
            //var profile = await _profiles.ByUser(_currentUser.GetId());

            //return profile;
            return null;
        }

        [HttpPut]
        public async Task<ActionResult<UpdateProfileResponseModel>> Update(UpdateProfileRequestModel model)
        {
            //var userId = _currentUser.GetId();

            //var res = await _profiles.Update(
            //    userId,
            //    model.Email,
            //    model.UserName,
            //    model.Name,
            //    model.MainPhotoUrl,
            //    model.Website,
            //    model.Biography,
            //    model.Gender,
            //    model.IsPrivate
            //    );

            //if (!res.Succeeded) return BadRequest(res.Error);
            //return Ok();
            return null;
        }
    }
}

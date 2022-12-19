namespace Api.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        public AdminController(IMediator mediator) : base(mediator)
        {

        }
    }
}

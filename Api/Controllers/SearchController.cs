namespace Api.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class SearchController : BaseController
    {

        public SearchController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<SearchItemsResponseModel>> SearchItems(SearchItemRequestModel model)
        {
            var res = await _mediator.Send(new SearchItemsQuery(model.Query));

            if (res.Succeeded) return Ok(res.Data);
            else return BadRequest(res.Error);
        }
    }
}

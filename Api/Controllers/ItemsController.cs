using Application.Commands.Items;
using Application.Infrastructure;
using Domain.Aggregates;
using static Application.Commands.Items.CreateItemCommand;

namespace Api.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class ItemsController : BaseController
    {
        private readonly IMediator _mediator;

        private readonly IItemsService _itemsService;

        private readonly ICurrentUserService _currentUser;

        public ItemsController(IItemsService itemsService, ICurrentUserService currentUser, IMediator mediator)
        {
            _itemsService = itemsService;
            _currentUser = currentUser;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ListingResponseModel>> Mine()
        {
            var userId = _currentUser.GetId();

            var items = await _itemsService.ByUser(userId);

            return items;

        }

        [HttpGet]
        [Route(Constants.WebConstants.Id)]
        public async Task<ActionResult<DetailsResponseModel>> Details(Guid id)
        {
            var item = await _itemsService.Details(id);

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateItemRequestModel model)
        {
            var res = await _mediator.Send<Result>(new CreateItemCommand( model.ImageUrl, model.Description));

            if(res.Succeeded) return Created(nameof(Create), 0); //TODO replace 0 with itemId
            else return BadRequest();
        }

        [HttpPut]
        [Route(Constants.WebConstants.Id)]
        public async Task<ActionResult> Update(Guid id, UpdateItemRequestModel model)
        {
            var userId = _currentUser.GetId();
            var res = await _itemsService.Update(
                id,
                model.Description,
                userId
                );

            if (!res.Succeeded) return BadRequest();
            return Ok();
        }

        [HttpDelete]
        [Route(Constants.WebConstants.Id)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var userId = _currentUser.GetId();
            var res = await _itemsService.Delete(id, userId);

            if (!res.Succeeded) return BadRequest();
            return Ok();
        }
    }
}

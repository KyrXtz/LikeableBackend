namespace Api.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class ItemsController : BaseController
    {
        private readonly IMediator _mediator;

        //private readonly IItemsService _itemsService;

        //private readonly ICurrentUserService _currentUser;

        public ItemsController(
            //IItemsService itemsService, ICurrentUserService currentUser,
            IMediator mediator)
        {
            //_itemsService = itemsService;
            //_currentUser = currentUser;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ItemListingResponseModel>> Mine([FromQuery] ItemListingRequestModel model)
        {
            //var userId = _currentUser.GetId();

            //var items = await _itemsService.ByUser(userId);

            //var res = new ItemListingResponseModel
            //{
            //    Items = items.Data.Select(x => new ItemListingResponseModel.Item
            //    {
            //        Id = Guid.Parse(GetValue(x, nameof(ItemListingResponseModel.Item.Id))),
            //        ImageUrl = GetValue(x, nameof(ItemListingResponseModel.Item.ImageUrl))
            //    })
            //};

            //if (res.Items.Any(i => i.Id == Guid.Empty || i.ImageUrl == String.Empty)) return BadRequest("There are items in the database with guid = 0 or no image.");
            //return Ok(res);
            return null;

        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<ItemDetailsResponseModel>> Details([FromQuery] ItemDetailsRequestModel model)
        {
            //var item = await _itemsService.Details(model.Id);

            //var res = new ItemDetailsResponseModel
            //{
            //    Id = Guid.Parse(GetValue(item.Data, nameof(ItemDetailsResponseModel.Id))),
            //    ImageUrl = GetValue(item.Data, nameof(ItemDetailsResponseModel.ImageUrl)),
            //    Description = GetValue(item.Data, nameof(ItemDetailsResponseModel.Description))
            //};
            //if (res.Id == Guid.Empty || res.ImageUrl == String.Empty) return BadRequest("There is an item in the database with guid = 0 or no image.");
            //return Ok(res);
            return null;
        }

        [HttpPost]
        public async Task<ActionResult<CreateItemResponseModel>> Create(CreateItemRequestModel model)
        {
            var res = await _mediator.Send(new CreateItemCommand(model.Title, model.ImageUrl, model.Description));

            if(res.Succeeded) return Created(nameof(Create), res.Data);
            else return BadRequest(res.Error);
        }

        [HttpPut]
        [Route(Constants.WebConstants.Id)]
        public async Task<ActionResult<UpdateItemResponseModel>> Update(UpdateItemRequestModel model)
        {
            //var userId = _currentUser.GetId();
            //var res = await _itemsService.Update(
            //    model.Id,
            //    model.Description,
            //    userId
            //    );

            //if (!res.Succeeded) return BadRequest();
            //return Ok();
            return null;
        }

        [HttpDelete]
        [Route(Constants.WebConstants.Id)]
        public async Task<ActionResult<DeleteItemResponseModel>> Delete(DeleteItemRequestModel model)
        {
            //var userId = _currentUser.GetId();
            //var res = await _itemsService.Delete(model.Id, userId);

            //if (!res.Succeeded) return BadRequest();
            //return Ok();
            return null;
        }
    }
}

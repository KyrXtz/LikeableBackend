﻿namespace Api.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ItemsController : BaseController
    {
        public ItemsController(IMediator mediator) : base(mediator)
        {
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
        public async Task<ActionResult<UpdateItemResponseModel>> Update([FromRoute] Guid id, 
            UpdateItemRequestModel model)
        {
            var res = await _mediator.Send(new UpdateItemCommand(id, model.Description));

            if (res.Succeeded) return Ok(res.Data);
            else return BadRequest(res.Error);
        }

        [HttpDelete]
        [Route(Constants.WebConstants.Id)]
        public async Task<ActionResult<DeleteItemResponseModel>> Delete([FromRoute] Guid id, 
            DeleteItemRequestModel model)
        {
            var res = await _mediator.Send(new DeleteItemCommand(id));

            if (res.Succeeded) return Ok(res.Data);
            else return BadRequest(res.Error);
        }

        [HttpGet]
        [Route(Constants.WebConstants.Id)]
        public async Task<ActionResult<ItemDetailsResponseModel>> ItemDetails([FromRoute] Guid id,
            [FromQuery] ItemDetailsRequestModel model)
        {
            var res = await _mediator.Send(new ItemDetailsQuery(id));

            if (res.Succeeded) return Ok(res.Data);
            else return BadRequest(res.Error);
        }
    }
}

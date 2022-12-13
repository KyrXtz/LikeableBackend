namespace Application.Commands.Items
{
    #region Command
    public class DeleteItemCommand : BaseCommand, IRequest<Result<DeleteItemResponseModel>>
    {
        public Guid ItemId { get; set; }

        public DeleteItemCommand(Guid itemId)
        {
            ItemId = itemId;
        }
    }
    #endregion
    #region Validation
    public class DeleteItemCommandValidator : AbstractValidator<DeleteItemCommand>
    {
        public DeleteItemCommandValidator()
        {
        }
    }
    #endregion
    #region Handler
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, Result<DeleteItemResponseModel>>
    {
        private readonly IItemsService _itemsService;
        private readonly ICurrentUserService _currentUserService;

        public DeleteItemCommandHandler(IItemsService itemsService, ICurrentUserService currentUserService)
        {
            _itemsService = itemsService;
            _currentUserService = currentUserService;
        }

        public async Task<Result<DeleteItemResponseModel>> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetId();
            var res = await _itemsService.Delete(
                request.ItemId,
                userId
                );
            if (!res.Succeeded) return res.Error;

            return res;
        }
    }
    #endregion

}

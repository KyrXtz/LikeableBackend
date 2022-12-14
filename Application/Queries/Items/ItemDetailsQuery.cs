namespace Application.Queries.Items
{
    #region Query
    public class ItemDetailsQuery : BaseQuery, IRequest<Result<ItemDetailsResponseModel>>
    {
        public Guid ItemId { get; set; }

        public ItemDetailsQuery(Guid itemId)
        {
            ItemId = itemId;
        }
    }
    #endregion
    #region Validation
    public class ItemDetailsQueryValidator : AbstractValidator<ItemDetailsQuery>
    {
        public ItemDetailsQueryValidator()
        {
            RuleFor(x => x.ItemId).NotEmpty().NotNull();
        }
    }
    #endregion
    #region Handler
    public class ItemDetailsQueryHandler : IRequestHandler<ItemDetailsQuery, Result<ItemDetailsResponseModel>>
    {
        private readonly IItemsService _itemsService;

        public ItemDetailsQueryHandler(IItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        public async Task<Result<ItemDetailsResponseModel>> Handle(ItemDetailsQuery request, CancellationToken cancellationToken)
        {
            var res = await _itemsService.ItemDetails(request.ItemId);
            if (!res.Succeeded) return res.Error;

            return res;
        }
    }
    #endregion

}

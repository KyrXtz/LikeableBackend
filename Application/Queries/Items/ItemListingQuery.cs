namespace Application.Queries.Items
{
    #region Command
    public class ItemListingQuery : BaseQuery, IRequest<Result<ItemListingResponseModel>>
    {
        public ItemListingQuery()
        {
        }
    }
    #endregion
    #region Validation
    public class ItemListingQueryValidator : AbstractValidator<ItemListingQuery>
    {
        public ItemListingQueryValidator()
        {
        }
    }
    #endregion
    #region Handler
    public class ItemListingQueryHandler : IRequestHandler<ItemListingQuery, Result<ItemListingResponseModel>>
    {
        private readonly IItemsService _itemsService;
        private readonly ICurrentUserService _currentUserService;


        public ItemListingQueryHandler(IItemsService itemsService, ICurrentUserService currentUserService)
        {
            _itemsService = itemsService;
            _currentUserService = currentUserService;
        }

        public async Task<Result<ItemListingResponseModel>> Handle(ItemListingQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetId();

            var res = await _itemsService.LikedItems(userId);
            if (!res.Succeeded) return res.Error;

            return res;
        }
    }
    #endregion

}

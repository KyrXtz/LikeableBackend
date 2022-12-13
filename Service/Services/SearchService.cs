namespace Service.Services
{
    public class SearchService : ISearchService
    {
        private readonly IAppDbContext<Item> _itemDbContext;

        public SearchService(IAppDbContext<Item> itemDbContext)
        {
            _itemDbContext = itemDbContext;
        }

        public async Task<Result<SearchItemResponseModel>> Items(string query)
        {
            var items = await _itemDbContext
                .EntitySet
                .Where(i => i.Description.Value.ToLower().Contains(query.ToLower())) //TODO change desc to name
                .Select(i => new SearchItemResponseModel.SearchItem
                {
                    ImageUrl = i.ImageUrl,
                    Description = i.Description.Value,
                    ItemId = i.Id
                })
                .ToListAsync();

            return new SearchItemResponseModel
            {
                Items = items
            };
        }
    }
}

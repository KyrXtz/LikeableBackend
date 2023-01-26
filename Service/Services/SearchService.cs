namespace Service.Services
{
    public class SearchService : ISearchService
    {
        private readonly IAppDbContext<Item> _itemDbContext;

        public SearchService(IAppDbContext<Item> itemDbContext)
        {
            _itemDbContext = itemDbContext;
        }

        public async Task<Result<SearchItemsResponseModel>> Items(string query)
        {
            var items = await _itemDbContext
                .EntitySet
                .Where(i => i.Title.ToLower().Contains(query.ToLower()) ||
                    i.Info.Description.ToLower().Contains(query.ToLower()))
                .Select(i => new SearchItemsResponseModel.SearchItem
                {
                    Title = i.Title,
                    ImageUrl = i.ImageUrl,
                    Description = i.Description.Description,
                    ItemId = i.Id
                })
                .ToListAsync();

            return new SearchItemsResponseModel
            {
                Items = items
            };
        }
    }
}

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
                .Where(i => i.Info.Title.ToLower().Contains(query.ToLower()) ||
                    i.Info.Description.ToLower().Contains(query.ToLower()))
                .Select(i => new SearchItemsResponseModel.SearchItem
                {
                    Title = i.Info.Title,
                    ImageUrl = i.Images.ImageList.FirstOrDefault(), //todo change
                    Description = i.Info.Description,
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

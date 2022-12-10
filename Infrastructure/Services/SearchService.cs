namespace Infrastructure.Services
{
    public class SearchService : ISearchService
    {
        private readonly AppDbContext _appDbContext;

        public SearchService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<SearchProfileResponseModel>> Items(string query)
        {
            var items = await _appDbContext
                .Items
                .Where(i => i.Description.Value.ToLower().Contains(query.ToLower())) //TODO change desc to name
                .Select(i => new SearchProfileResponseModel
                {
                    ImageUrl = i.ImageUrl,
                    Description = i.Description.Value,
                    ItemId = i.Id
                })
                .ToListAsync();

            return items;
        }
    }
}

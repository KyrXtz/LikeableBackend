namespace Infrastructure.Services
{
    public class ItemsService : IItemsService
    {
        private readonly AppDbContext _appDbContext;
        public ItemsService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Create(string imageUrl, string description)
        {
            var item = Item.Create(imageUrl, description);
            
            _appDbContext.Add(item);

            await _appDbContext.SaveChangesAsync();

            return item.Id;
        }

        public async Task<IEnumerable<ListingResponseModel>> ByUser(string userId)
        {
           var items = await _appDbContext.Items
                //.Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new ListingResponseModel
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl
                })
                .ToListAsync();
            return items;
        }

        public async Task<DetailsResponseModel> Details(Guid id)
        {
            var item = await _appDbContext.Items
                .Where(x => x.Id == id)
                .Select(x => new DetailsResponseModel
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description.Value,
                })
                .FirstOrDefaultAsync();
            return item;
        }

        public async Task<Result> Update(Guid id, string description, string userId)
        {
            var item = await ByIdAndUserId(id, userId);

            if (item == null) return "This user cannot edit this item.";

            //item.Description = description; //TODO change to factory method

            await this._appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Result> Delete(Guid id, string userId)
        {
            var item = await ByIdAndUserId(id, userId);

            if (item == null) return "This user cannot delete this item.";

            _appDbContext.Items.Remove(item);

            await _appDbContext.SaveChangesAsync();

            return true;
        }

        private async Task<Item> ByIdAndUserId(Guid id, string userId)
            => await _appDbContext.Items
                .Where(c => c.Id == id )//&& c.UserId == userId)
                .FirstOrDefaultAsync();
    }
}

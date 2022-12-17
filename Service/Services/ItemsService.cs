namespace Service.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IAppDbContext<Item> _itemsDbContext;
        public ItemsService(IAppDbContext<Item> itemsDbContext)
        {
            _itemsDbContext = itemsDbContext;
        }

        public async Task<Result<CreateItemResponseModel>> Create(string title, string imageUrl, string description)
        {
            var item = Item.Create(title, imageUrl, description);
            
            _itemsDbContext.EntitySet.Add(item);

            await _itemsDbContext.SaveChangesAsync();

            return new CreateItemResponseModel
            {
                Id = item.Id
            };
        }

        public async Task<Result<ItemListingResponseModel>> LikedItems(string userId)
        {
            var items = await _itemsDbContext.EntitySet
                 //.Where(x => x.UserId == userId)
                 .OrderByDescending(x => x.CreatedOn)
                 .Select(x => new ItemListingResponseModel.Item
                 {
                     Id = x.Id, 
                     ImageUrl = x.ImageUrl 
                 }).ToListAsync();
            return new ItemListingResponseModel
            {
                Items = items
            };
        }

        public async Task<Result<ItemDetailsResponseModel>> ItemDetails(Guid id)
        {
            var item = await _itemsDbContext.EntitySet
                .Where(x => x.Id == id)
                .Select(x => new ItemDetailsResponseModel
                 {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl ,
                    Description = x.Description.Value 
                 })
                .FirstOrDefaultAsync();

            if (item.Id == Guid.Empty || item.ImageUrl == string.Empty) return "There is an item in the database with guid = 0 or no image.";

            return item;
        }

        public async Task<Result<UpdateItemResponseModel>> Update(Guid id, string description, string userId)
        {
            var item = await ByIdAndUserId(id, userId);

            if (item == null) return "This user cannot edit this item.";

            item.Update(description: description);

            await this._itemsDbContext.SaveChangesAsync();

            return new UpdateItemResponseModel
            {
                Updated = true
            };
        }

        public async Task<Result<DeleteItemResponseModel>> Delete(Guid id, string userId)
        {
            var item = await ByIdAndUserId(id, userId);

            if (item == null) return "This user cannot delete this item.";

            _itemsDbContext.EntitySet.Remove(item);

            await _itemsDbContext.SaveChangesAsync();

            return new DeleteItemResponseModel
            {
                Deleted = true
            };
        }

        private async Task<Item> ByIdAndUserId(Guid id, string userId)
            => await _itemsDbContext.EntitySet
                .Where(c => c.Id == id )//&& c.UserId == userId)
                .FirstOrDefaultAsync();
    }
}

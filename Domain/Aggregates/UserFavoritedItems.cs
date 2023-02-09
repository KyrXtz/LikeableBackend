namespace Domain.Aggregates
{
    public class UserFavoritedItem : BaseEntity
    {
        public Guid ItemId { get; private set; }
        public string UserId { get; private set; }
        private UserFavoritedItem() { }
        private UserFavoritedItem(Guid itemId, string userId) 
        {
            Id = Guid.NewGuid();
            ItemId = itemId;
            UserId = userId;
        }
        public static UserFavoritedItem Create(Guid itemId, string userId)
        {
            return new UserFavoritedItem(itemId, userId);
        }
    }
}

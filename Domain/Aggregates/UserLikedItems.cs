namespace Domain.Aggregates
{
    public class UserLikedItems : BaseEntity
    {
        public Guid ItemId { get; private set; }
        public string UserId { get; private set; }
        private UserLikedItems() { }
        private UserLikedItems(Guid itemId, string userId) 
        {
            Id = Guid.NewGuid();
            ItemId = itemId;
            UserId = userId;
        }
        public static UserLikedItems Create(Guid itemId, string userId)
        {
            return new UserLikedItems(itemId, userId);
        }


    }
}

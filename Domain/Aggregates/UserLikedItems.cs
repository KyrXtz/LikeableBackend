namespace Domain.Aggregates
{
    public class UserLikedItem : BaseEntity
    {
        public Guid ItemId { get; private set; }
        public string UserId { get; private set; }
        private UserLikedItem() { }
        private UserLikedItem(Guid itemId, string userId) 
        {
            Id = Guid.NewGuid();
            ItemId = itemId;
            UserId = userId;
        }
        public static UserLikedItem Create(Guid itemId, string userId)
        {
            return new UserLikedItem(itemId, userId);
        }


    }
}

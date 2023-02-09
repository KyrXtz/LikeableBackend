namespace Domain.Aggregates
{
    public class User : BaseUser, IAggregateRoot
    {
        public Profile Profile { get; private set; }

        private List<UserLikedItem> likedItems;
        public IReadOnlyCollection<UserLikedItem> LikedItems => likedItems.AsReadOnly();

        private List<UserFavoritedItem> favoritedItems;
        public IReadOnlyCollection<UserFavoritedItem> FavoritedItems => favoritedItems.AsReadOnly();

        private List<UserOrder> userOrders;
        public IReadOnlyCollection<UserOrder> UserOrders => userOrders.AsReadOnly();

        private User() { likedItems = new List<UserLikedItem>(); favoritedItems = new List<UserFavoritedItem>(); userOrders = new List<UserOrder>(); }
        internal User(Profile profile, string username, string email)
        {
            base.Email = email;
            base.UserName = username;
            Profile = profile;
            CreatedOn = DateTime.UtcNow;
            CreatedBy = username;
            likedItems = new List<UserLikedItem>();
            favoritedItems = new List<UserFavoritedItem>();
            userOrders = new List<UserOrder>();
        }

        public static User Create(string username, string email)
        {
            var emptyProfile = Profile.Create(null, null);
            return new User(emptyProfile, username, email);
        }

        public void UpdateProfile(string? name = null, string? mainPhotoUrl = null)
        {
            Profile = Profile.Create(name ?? Profile.Name, mainPhotoUrl ?? Profile.MainPhotoUrl);
        }
    }
}
 
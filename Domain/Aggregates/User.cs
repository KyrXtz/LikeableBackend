namespace Domain.Aggregates
{
    public class User : BaseUser, IAggregateRoot
    {
        public Profile Profile { get; private set; }
        public IEnumerable<Item> Items { get; } = new HashSet<Item>();
        private User() { }
        internal User(Profile profile, string username, string email)
        {
            base.Email = email;
            base.UserName = username;
            Profile = profile;
            CreatedOn = DateTime.UtcNow;
            CreatedBy = username;
        }

        public static User Create(string username, string email)
        {
            var emptyProfile = Profile.Create(null, null);
            return new User(emptyProfile, username, email);
        }

        public void UpdateProfile(string? name = null, string? mainPhotoUrl = null)
        {
            if(name == null) name = Profile.Name;
            if(mainPhotoUrl == null) mainPhotoUrl = Profile.MainPhotoUrl;

            Profile = Profile.Create(name, mainPhotoUrl);
        }
    }
}
 
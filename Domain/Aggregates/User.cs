namespace Domain.Aggregates
{
    public class User : BaseUser, IAggregateRoot
    {
        public Profile Profile { get; set; }
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
    }
}
 
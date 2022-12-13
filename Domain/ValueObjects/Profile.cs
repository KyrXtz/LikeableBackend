namespace Domain.ValueObjects
{
    public class Profile : ValueObject
    {
        public string? Name { get; private set; }
        public string? MainPhotoUrl { get; private set; }
        internal Profile(string? name, string? mainPhotoUrl)
        {
            Name = name;
            MainPhotoUrl = mainPhotoUrl;
        }

        public static Profile Create(string? name, string? mainPhotoUrl)
        {
            return new Profile(name, mainPhotoUrl);
        }
    }
}

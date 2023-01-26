namespace Domain.ValueObjects.Item
{
    public class Info : ValueObject
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        internal Info(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public static Info Create(string title, string description)
        {
            return new Info(title, description);
        }
    }
}

namespace Domain.Aggregates
{
    public class Item : DeletableBaseEntity , IAggregateRoot
    {    
        public string Title { get; private set; }
        public Description Description { get; private set; }
        public string ImageUrl { get; private set; }

        /// <summary>
        /// needed by ef core
        /// </summary>
        private Item() { }
        public Item(Guid id,string title, Description description, string imageUrl)
        {
            Id = id;
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
        }

        public static Item Create(string title, string imageUrl, string descriptionValue)
        {
            var id = Guid.NewGuid();
            var description = Description.Create(descriptionValue);
            return new Item(id, title, description, imageUrl);
        }
    }
}

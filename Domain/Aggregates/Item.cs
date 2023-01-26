using Domain.ValueObjects.Item;

namespace Domain.Aggregates
{
    public class Item : DeletableBaseEntity , IAggregateRoot
    {    
        public string Title { get; private set; }
        public Info Description { get; private set; }
        public string ImageUrl { get; private set; }

        /// <summary>
        /// needed by ef core
        /// </summary>
        private Item() { }
        public Item(Guid id,string title, Info description, string imageUrl)
        {
            Id = id;
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
        }

        public static Item Create(string title, string imageUrl, string descriptionValue)
        {
            var id = Guid.NewGuid();
            var description = Info.Create(descriptionValue);
            return new Item(id, title, description, imageUrl);
        }

        public void Update(string? title = null, string? description = null)
        {
            //if (title != null) Title = Title.Create(title);
            if (description != null) Description = Info.Create(description);
        }
    }
}

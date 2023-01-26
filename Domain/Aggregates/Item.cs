using Domain.ValueObjects.Item;

namespace Domain.Aggregates
{
    public class Item : DeletableBaseEntity , IAggregateRoot
    {    
        public Info Info { get; private set; }
        public Comments Comments { get; private set; }
        public Images Images { get; private set; }
        public Sound Sound { get; private set; }
        public PrintDetails PrintDetails { get; private set; }

        /// <summary>
        /// needed by ef core
        /// </summary>
        private Item() { }

        public Item(Guid id, Info info, Comments comments, Images images, Sound sound, PrintDetails printDetails)
        {
            Id = id;
            Info = info;
            Comments = comments;
            Images = images;
            Sound = sound;
            PrintDetails = printDetails;
        }

        public static Item Create(string title, string description, string[] imageArray, string soundPath, string[] commentsArray,
            TimeSpan time, double filament, double height, bool handPainted)
        {
            var id = Guid.NewGuid();
            var info = Info.Create(title, description);
            var images = Images.Create(imageArray.ToList());
            var sound = Sound.Create(soundPath);
            var comments = Comments.Create(commentsArray.ToList());
            var printDetails = PrintDetails.Create(time, filament, height, handPainted);

            return new Item(id, info, comments, images, sound, printDetails);
        }

        public void Update(string? title = null, string? description = null)
        {
            Info = Info.Create( title ?? Info.Title, description ?? Info.Description);
        }
    }
}

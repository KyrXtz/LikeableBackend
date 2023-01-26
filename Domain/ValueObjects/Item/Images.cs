namespace Domain.ValueObjects.Item
{
    public class Images : ValueObject
    {
        public IEnumerable<string> ImageList { get; private set; }

        internal Images(IEnumerable<string> imageList)
        {
            ImageList = imageList;
        }

        public static Images Create(IEnumerable<string> imageList)
        {
            return new Images(imageList);
        }
    }
}

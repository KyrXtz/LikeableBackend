namespace SharedKernel.Models.Response.User
{
    public class LikedItemsResponseModel
    {
        public IEnumerable<Item> Items { get; set; }

        public class Item
        {
            public Guid Id { get; set; }
            public string ImageUrl { get; set; }
        }
    }
}

namespace Common.Models.Response.Items
{
    public class ItemListingResponseModel
    {
        public IEnumerable<Item> Items { get; set; }
       
        public class Item
        {
            public Guid Id { get; set; }
            public string ImageUrl { get; set; }
        }
    }
}

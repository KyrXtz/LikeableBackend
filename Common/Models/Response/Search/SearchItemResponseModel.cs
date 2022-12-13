namespace SharedKernel.Models.Response.Search
{
    public class SearchItemResponseModel
    {
        public IEnumerable<SearchItem> Items { get; set; }
        public class SearchItem
        {
            public Guid ItemId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string ImageUrl { get; set; }
        }
    }
}

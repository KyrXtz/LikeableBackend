namespace Common.Models.Request.Items
{
    public class CreateItemRequestModel
    {
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        public CreateItemRequestModel(string imageUrl, string description)
        {            
            ImageUrl = imageUrl;
            Description = description;
        }
    }
}

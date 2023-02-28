namespace SharedKernel.Models.Response.User
{
    public class GetProfileResponseModel
    {
        //[MaxLength(MaxNameLength)]
        public string? Name { get; set; }
        public string? MainPhotoUrl { get; set; }
    }
}

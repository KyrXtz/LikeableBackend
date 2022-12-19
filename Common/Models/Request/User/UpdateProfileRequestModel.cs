namespace SharedKernel.Models.Request.User
{
    public class UpdateProfileRequestModel
    {
        //[MaxLength(MaxNameLength)]
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? MainPhotoUrl { get; set; }
    }
}

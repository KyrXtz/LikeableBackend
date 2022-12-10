namespace Application.Infrastructure.Services
{
    public interface IProfileService
    {
        Task<UpdateProfileResponseModel> ByUser(string userId);
        Task<Result<bool>> Update( //TODO change response to Dictionary<string,string>
            string userId,
            string email,
            string userName,
            string name,
            string mainPhotoUrl,
            string website,
            string biography,
            Gender gender,
            bool isPrivate);
    }
}

namespace Application.Infrastructure.Services
{
    public interface IProfileService
    {
        Task<UpdateProfileResponseModel> ByUser(string userId);
        Task<Result> Update(
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

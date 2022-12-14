namespace SharedKernel.Interfaces
{
    public interface IProfileService
    {
        Task<Result<GetProfileResponseModel>> ByUser(string userId);
        Task<Result<UpdateProfileResponseModel>> UpdateUserName(string userId,
            string userName);
        Task<Result<UpdateProfileResponseModel>> UpdateProfile(string userId,
            string name,
            string mainPhotoUrl);
    }
}

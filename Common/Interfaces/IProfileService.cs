namespace SharedKernel.Interfaces
{
    public interface IProfileService
    {
        Task<Result<GetProfileResponseModel>> ByUser(string userId);
        Task<Result<UpdateProfileResponseModel>> Update(string userId,
            string email,
            string userName,
            string name,
            string mainPhotoUrl);
    }
}

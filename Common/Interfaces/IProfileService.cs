namespace SharedKernel.Interfaces
{
    public interface IProfileService
    {
        Task<Result<GetProfileResponseModel>> ByUser(string userId);
        Task<Result<UpdateProfileResponseModel>> Update(string userId,
            string userName,
            string name,
            string mainPhotoUrl);
    }
}

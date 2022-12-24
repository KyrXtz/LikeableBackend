namespace SharedKernel.Interfaces
{
    public interface IUserService
    {
        Task<Result<GetUserNameResponseModel>> GetUserName(string userId);
        Task<Result<LikedItemsResponseModel>> LikedItems(string userId);
        Task<Result<GetProfileResponseModel>> GetProfile(string userId);
        Task<Result<UpdateProfileResponseModel>> UpdateUserName(string userId,
            string userName);
        Task<Result<UpdateProfileResponseModel>> UpdateProfile(string userId,
            string name,
            string mainPhotoUrl);

    }
}

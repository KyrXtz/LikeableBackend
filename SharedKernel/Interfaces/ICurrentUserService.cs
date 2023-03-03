namespace SharedKernel.Interfaces
{
    public interface ICurrentUserService
    {
        Task<Result<GetCurrentUserIdResponseModel>> GetCurrentUserId();
    }
}

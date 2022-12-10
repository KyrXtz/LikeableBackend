namespace Application.Infrastructure.Services
{
    public interface IItemsService
    {
        Task<Result<Guid>> Create(string title, string imageUrl, string description);
        Task<Result<List<Dictionary<string, string>>>> ByUser(string userId);
        Task<Result<Dictionary<string, string>>> Details(Guid id);
        Task<Result<bool>> Update(Guid id, string description, string userId);
        Task<Result<bool>> Delete(Guid id, string userId);
    }
}

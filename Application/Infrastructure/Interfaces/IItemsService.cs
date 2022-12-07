namespace Application.Infrastructure.Services
{
    public interface IItemsService
    {
        Task<Guid> Create(string imageUrl, string description);
        Task<IEnumerable<ListingResponseModel>> ByUser(string userId);
        Task<DetailsResponseModel> Details(Guid id);
        Task<Result> Update(Guid id, string description, string userId);
        Task<Result> Delete(Guid id, string userId);
    }
}

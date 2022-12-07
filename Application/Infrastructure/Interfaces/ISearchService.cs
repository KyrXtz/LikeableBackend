namespace Application.Infrastructure.Services
{
    public interface ISearchService
    {
        Task<IEnumerable<SearchProfileResponseModel>> Items(string query);
    }
}

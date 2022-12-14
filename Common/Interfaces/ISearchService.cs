namespace SharedKernel.Interfaces
{
    public interface ISearchService
    {
        Task<Result<SearchItemsResponseModel>> Items(string query);
    }
}

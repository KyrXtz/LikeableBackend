namespace SharedKernel.Interfaces
{
    public interface ISearchService
    {
        Task<Result<SearchItemResponseModel>> Items(string query);
    }
}

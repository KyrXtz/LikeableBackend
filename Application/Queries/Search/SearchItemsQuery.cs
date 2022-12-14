namespace Application.Queries.Search
{   
    #region Query
    public class SearchItemsQuery : BaseQuery, IRequest<Result<SearchItemsResponseModel>>
    {
        public string Query { get; set; }

        public SearchItemsQuery(string query)
        {
            Query = query;
        }
    }
    #endregion
    #region Validation
    public class SearchItemsQueryValidator : AbstractValidator<SearchItemsQuery>
    {
        public SearchItemsQueryValidator()
        {
            RuleFor(x => x.Query).NotEmpty().NotNull();
        }
    }
    #endregion
    #region Handler
    public class SearchItemsQueryHandler : IRequestHandler<SearchItemsQuery, Result<SearchItemsResponseModel>>
    {
        private readonly ISearchService _searchService;

        public SearchItemsQueryHandler(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public async Task<Result<SearchItemsResponseModel>> Handle(SearchItemsQuery request, CancellationToken cancellationToken)
        {
            var res = await _searchService.Items(request.Query);
            if (!res.Succeeded) return res.Error;

            return res;
        }
    }
    #endregion



}

﻿namespace Api.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class SearchController : BaseController
    {

        public SearchController(
            //ISearchService searchService
            )
        {
           // _searchService = searchService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route(nameof(Constants.WebConstants.Search))]
        public async Task<IEnumerable<SearchItemResponseModel>> Items(string query)
        {
            //var items = await _searchService.Items(query);
            //return items;
            return null;
        }
    }
}

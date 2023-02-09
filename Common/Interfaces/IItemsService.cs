namespace SharedKernel.Interfaces
{
    public interface IItemsService
    {
        Task<Result<CreateItemResponseModel>> Create(string title, string imageUrl, string description);
        Task<Result<ItemDetailsResponseModel>> ItemDetails(Guid id);
        Task<Result<UpdateItemResponseModel>> Update(Guid id, string title, string description);
        Task<Result<DeleteItemResponseModel>> Delete(Guid id);
    }
}

﻿namespace SharedKernel.Interfaces
{
    public interface IItemsService
    {
        Task<Result<CreateItemResponseModel>> Create(string title, string imageUrl, string description);
        Task<Result<ItemListingResponseModel>> LikedItems(string userId);
        Task<Result<ItemDetailsResponseModel>> ItemDetails(Guid id);
        Task<Result<UpdateItemResponseModel>> Update(Guid id, string description, string userId);
        Task<Result<DeleteItemResponseModel>> Delete(Guid id, string userId);
    }
}
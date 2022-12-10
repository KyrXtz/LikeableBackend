namespace Application.Commands.Items
{
    #region Command
    public class CreateItemCommand : BaseCommand, IRequest<Result<CreateItemResponseModel>>
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        public CreateItemCommand (string title, string imageUrl, string description)
        {
            Title = title;
            ImageUrl = imageUrl;
            Description = description;
        }
    }
    #endregion
    #region Validation
    public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidator()
        {
            RuleFor(x => x.Description.Length).LessThanOrEqualTo(2000);
        }
    }
    #endregion
    #region Handler
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand,Result<CreateItemResponseModel>>
    {
        private readonly IItemsService _itemsService;

        private readonly ICurrentUserService _currentUser;
        public CreateItemCommandHandler(IItemsService itemsService, ICurrentUserService currentUser)
        {
            _itemsService = itemsService;
            _currentUser = currentUser;
        }

        public async Task<Result<CreateItemResponseModel>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUser.GetId();
            var itemId = await _itemsService.Create(request.Title, request.ImageUrl, request.Description);

            if (itemId.Data == Guid.Empty) return "Insert failed. Check logs.";

            return new CreateItemResponseModel
            {
                Id = itemId.Data
            };
        }
    }
    #endregion

}

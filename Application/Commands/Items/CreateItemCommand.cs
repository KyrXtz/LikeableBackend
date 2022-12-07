namespace Application.Commands.Items
{
    public class CreateItemCommand : BaseCommand, IRequest<Result>
    {
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        public CreateItemCommand(string imageUrl, string description)
        {
            ImageUrl = imageUrl;
            Description = description;
        }
    }
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand,Result>
    {
        private readonly IItemsService _itemsService;

        private readonly ICurrentUserService _currentUser;
        public CreateItemCommandHandler(IItemsService itemsService, ICurrentUserService currentUser)
        {
            _itemsService = itemsService;
            _currentUser = currentUser;
        }

        public async Task<Result> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUser.GetId();
            var itemId = await _itemsService.Create(request.ImageUrl, request.Description);
            return true;
        }
    }

}

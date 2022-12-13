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
        public CreateItemCommandValidator(IOptions<ValidationSettings> options)
        {
            RuleFor(x => x.Description).NotNull();
            RuleFor(x => x.Description.Length).LessThanOrEqualTo(Convert.ToInt32(options.Value.MaxDescriptionLength));
        }
    }
    #endregion
    #region Handler
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand,Result<CreateItemResponseModel>>
    {
        private readonly IItemsService _itemsService;

        public CreateItemCommandHandler(IItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        public async Task<Result<CreateItemResponseModel>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var res = await _itemsService.Create(request.Title, request.ImageUrl, request.Description);
            if (!res.Succeeded) return res.Error;

            return res;
        }
    }
    #endregion

}

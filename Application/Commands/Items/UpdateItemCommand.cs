namespace Application.Commands.Items
{
    #region Command
    public class UpdateItemCommand : BaseCommand, IRequest<Result<UpdateItemResponseModel>>
    {
        public Guid ItemId { get; set; }
        public string Description { get; set; }

        public UpdateItemCommand(Guid itemId, string description)
        {
            ItemId = itemId;
            Description = description;
        }
    }
    #endregion
    #region Validation
    public class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommand>
    {
        public UpdateItemCommandValidator(IOptions<ValidationSettings> options)
        {
            RuleFor(x => x.Description).NotNull();
            RuleFor(x => x.Description.Length).LessThanOrEqualTo(Convert.ToInt32(options.Value.MaxDescriptionLength));
        }
    }
    #endregion
    #region Handler
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, Result<UpdateItemResponseModel>>
    {
        private readonly IItemsService _itemsService;

        public UpdateItemCommandHandler(IItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        public async Task<Result<UpdateItemResponseModel>> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var res = await _itemsService.Update(
                request.ItemId,
                "", //todo
                request.Description
                );
            if (!res.Succeeded) return res.Error;

            return res;
        }
    }
    #endregion

}

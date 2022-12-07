namespace Common.Models.Request.Items
{
    public class UpdateItemRequestModel
    {
        private readonly ValidationSettings _validationSettings;
        public string Description { get; set; }

        public UpdateItemRequestModel(IOptions<ValidationSettings> validationSettingsOptions, string description)
        {
            _validationSettings = validationSettingsOptions.Value;

            Guard.Against.NullOrEmpty(description, nameof(description));
            Guard.Against.NullOrWhiteSpace(description, nameof(description));

            Description = description;
        }
    }
}

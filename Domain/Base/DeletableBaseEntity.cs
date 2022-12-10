namespace Domain.Base
{
    public class DeletableBaseEntity : BaseEntity , IDeletableEntity
    {
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
        public bool isDeleted { get; set; }
    }
}

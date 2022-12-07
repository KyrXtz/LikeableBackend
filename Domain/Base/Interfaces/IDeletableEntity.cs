namespace Domain.Base.Interfaces
{
    public interface IDeletableEntity : IEntity
    {
        DateTime? DeletedOn { get; set; }
        string? DeletedBy { get; set; }
        bool isDeleted { get; set; }
    }
}

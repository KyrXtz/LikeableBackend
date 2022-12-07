namespace Domain.Base.Interfaces
{
    public interface IEntity
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }

        string? CreatedBy { get; set; }

        string? ModifiedBy { get; set; }
    }
}

namespace SharedKernel.Interfaces
{
    public interface IAppDbContext<T> 
        where T : class
    {
        DbSet<T> EntitySet { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

namespace Infrastructure.Ef
{
    public class AppDbContext : IdentityDbContext<User>,
        IAppDbContext<User>, IAppDbContext<Item>
    {
        private readonly ICurrentUserService _currentUser;
        public AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUserService currentUser)
            : base(options)
        {
            _currentUser = currentUser;
        }
        DbSet<Item> IAppDbContext<Item>.EntitySet { get; set; }
        DbSet<User> IAppDbContext<User>.EntitySet { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInformation();
            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyAllConfigurationsFromCurrentAssembly();
        }

        private void ApplyAuditInformation()
        {
            ChangeTracker
                .Entries()
                .ToList()
                .ForEach(entry =>
                {
                    var username = _currentUser.GetUserName();

                    if (entry.Entity is IDeletableEntity deletableEntity)
                    {
                        if (entry.State == EntityState.Deleted)
                        {
                            deletableEntity.DeletedOn = DateTime.UtcNow;
                            deletableEntity.DeletedBy = username;
                            deletableEntity.isDeleted = true;

                            entry.State = EntityState.Modified;
                            return;
                        }
                    }
                    if (entry.Entity is ValueObject valueObject)
                    {
                        if (entry.State == EntityState.Deleted)
                        {
                            entry.State = EntityState.Modified;
                            return;
                        }
                    }
                    if (entry.Entity is IEntity entity)
                    {
                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedOn = DateTime.UtcNow;
                            entity.CreatedBy = username;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            entity.ModifiedOn = DateTime.UtcNow;
                            entity.ModifiedBy = username;
                        }
                    }


                });

        }
    }
}
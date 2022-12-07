using Domain.Base.Interfaces;

namespace Infrastructure.Ef
{
    public class AppDbContext : IdentityDbContext<User>
    {
        private readonly ICurrentUserService _currentUser;
        public AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUserService currentUser)
            : base(options)
        {
            _currentUser = currentUser;
        }
        public DbSet<Item> Items { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ApplyAuditInformation();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplyAuditInformation();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Item>()
                .HasQueryFilter(c => !c.isDeleted);

            builder
                .Entity<User>()
                .OwnsOne(c => c.Profile)
                .WithOwner();

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
namespace Infrastructure.Ef.Mappings
{
    class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .OwnsOne(c => c.Profile)
                .WithOwner();

            builder.HasKey(x => x.Id);

            builder.OwnsOne(p => p.Profile, p =>
            {
                p.Property(x => x.Name).HasColumnName("Name").HasMaxLength(200);
                p.Property(x => x.MainPhotoUrl).HasColumnName("MainPhotoUrl");
            });

            builder.HasMany(p => p.LikedItems)
                .WithOne()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}

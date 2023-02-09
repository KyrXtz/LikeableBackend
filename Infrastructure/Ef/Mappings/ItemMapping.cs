namespace Infrastructure.Ef.Mappings
{
    class ItemMapping : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");

            builder
                .HasQueryFilter(c => !c.isDeleted);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.OwnsOne(p => p.Info, p =>
            {
                p.Property(x => x.Description).HasColumnName("Description").HasMaxLength(3000);
                p.Property(x => x.Title).HasColumnName("Title").HasMaxLength(100);
            });

            builder.OwnsOne(p => p.Comments, p =>
            {
                p.Property(x => x.CommentList).HasConversion(
                    cmnt => string.Join(",", cmnt),
                    cmnt => cmnt.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
            });

            builder.OwnsOne(p => p.Images, p =>
            {
                p.Property(x => x.ImageList).HasConversion(
                    img => string.Join(",", img),
                    img => img.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
            });

            builder.OwnsOne(p => p.Sound, p =>
            {
                p.Property(x => x.SoundPath).HasColumnName("SoundPath");
            });

            builder.OwnsOne(p => p.PrintDetails, p =>
            {
                p.Property(x => x.HandPainted).HasColumnName("HandPainted");
                p.Property(x => x.Filament).HasColumnName("Filament");
                p.Property(x => x.Height).HasColumnName("Height");
                p.Property(x => x.Time).HasColumnName("Time");
            });

            builder.HasMany<UserLikedItem>()
                .WithOne()
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasMany<UserFavoritedItem>()
                .WithOne()
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}

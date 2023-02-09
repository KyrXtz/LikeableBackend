namespace Infrastructure.Ef.Mappings
{
    class UserFavoritedItemsMapping : IEntityTypeConfiguration<UserFavoritedItem>
    {
        public void Configure(EntityTypeBuilder<UserFavoritedItem> builder)
        {
            builder.ToTable("UserFavoritedItems");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever(); 

             builder.HasOne<User>()
                .WithMany(x => x.FavoritedItems)
                .HasForeignKey(x => x.UserId);

            builder.HasOne<Item>()
                .WithMany()
                .HasForeignKey(x => x.ItemId);
        }
    }
}

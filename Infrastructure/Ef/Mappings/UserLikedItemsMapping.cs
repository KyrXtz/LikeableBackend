namespace Infrastructure.Ef.Mappings
{
    class UserLikedItemsMapping : IEntityTypeConfiguration<UserLikedItem>
    {
        public void Configure(EntityTypeBuilder<UserLikedItem> builder)
        {
            builder.ToTable("UserLikedItems");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever(); 

             builder.HasOne<User>()
                .WithMany(x => x.LikedItems)
                .HasForeignKey(x => x.UserId);

            builder.HasOne<Item>()
                .WithMany()
                .HasForeignKey(x => x.ItemId);
        }
    }
}

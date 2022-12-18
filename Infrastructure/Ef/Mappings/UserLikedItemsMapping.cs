namespace Infrastructure.Ef.Mappings
{
    class UserLikedItemsMapping : IEntityTypeConfiguration<UserLikedItems>
    {
        public void Configure(EntityTypeBuilder<UserLikedItems> builder)
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

﻿namespace Infrastructure.Ef.Mappings
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
            });

            builder.HasMany<UserLikedItem>()
                .WithOne()
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}

namespace Infrastructure.Ef.Mappings
{
    class ItemMapping : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.OwnsOne(p => p.Description, p =>
            {
                p.Property(x => x.Value).HasColumnName("Description").HasMaxLength(3000);
            });
        }
    }
}

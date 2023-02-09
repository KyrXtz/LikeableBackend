namespace Infrastructure.Ef.Mappings
{
    class OrderSelectedItemsMapping : IEntityTypeConfiguration<OrderSelectedItem>
    {
        public void Configure(EntityTypeBuilder<OrderSelectedItem> builder)
        {
            builder.ToTable("OrderSelectedItems");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever(); 

             builder.HasOne<Order>()
                .WithMany(x => x.OrderSelectedItems)
                .HasForeignKey(x => x.OrderId);

            builder.HasOne<SelectedItem>()
                .WithMany()
                .HasForeignKey(x => x.SelectedItemId);
        }
    }
}

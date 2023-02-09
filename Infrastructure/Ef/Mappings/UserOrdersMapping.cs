namespace Infrastructure.Ef.Mappings
{
    class UserOrdersMapping : IEntityTypeConfiguration<UserOrder>
    {
        public void Configure(EntityTypeBuilder<UserOrder> builder)
        {
            builder.ToTable("UserOrders");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever(); 

             builder.HasOne<User>()
                .WithMany(x => x.UserOrders)
                .HasForeignKey(x => x.UserId);

            builder.HasOne<Order>()
                .WithOne()
                .HasForeignKey<UserOrder>(x => x.OrderId);
        }
    }
}

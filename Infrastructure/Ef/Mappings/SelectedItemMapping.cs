namespace Infrastructure.Ef.Mappings
{
    class SelectedItemMapping : IEntityTypeConfiguration<SelectedItem>
    {
        public void Configure(EntityTypeBuilder<SelectedItem> builder)
        {
            builder.ToTable("SelectedItems");

            builder.OwnsOne(p => p.SpecificPrintDetails, p =>
            {
                p.Property(x => x.HandPainted).HasColumnName("HandPainted");
                p.Property(x => x.Filament).HasColumnName("Filament");
                p.Property(x => x.Height).HasColumnName("Height");
                p.Property(x => x.Time).HasColumnName("Time");
            });
        }
    }
}

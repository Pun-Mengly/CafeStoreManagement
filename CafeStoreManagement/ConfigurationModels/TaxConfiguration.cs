using CafeStoreManagement.Models;

namespace CafeStoreManagement.ConfigurationModels
{
    public class TaxConfiguration : IEntityTypeConfiguration<TaxModel>
    {
        public void Configure(EntityTypeBuilder<TaxModel> builder)
        {
            builder.ToTable("tblTax");
            builder.Property(t => t.Code)
                    .IsRequired()
                    .HasMaxLength(5);
            builder.Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(t => t.Description)
                   .IsRequired(false)
                   .HasMaxLength(300);
            builder.Property(t => t.Percentage)
                   .IsRequired();
            builder.Property(t => t.IsDeleted)
                   .IsRequired();
            builder.HasIndex(t => new { t.Code, t.CreatedBy }).IsUnique();
        }
    }
}
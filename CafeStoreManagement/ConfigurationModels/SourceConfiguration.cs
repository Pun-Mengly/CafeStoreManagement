using CafeStoreManagement.Models;

namespace CafeStoreManagement.ConfigurationModels
{
    public class SourceConfiguration : IEntityTypeConfiguration<SourceModel>
    {
        public void Configure(EntityTypeBuilder<SourceModel> builder)
        {

            builder.ToTable("tblSource");
            builder.Property(t => t.Code)
                    .IsRequired()
                    .HasMaxLength(5);
            builder.Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(t => t.Abv)
                    .IsRequired()
                    .HasMaxLength(5);
            builder.Property(t => t.Description)
                   .IsRequired(false)
                   .HasMaxLength(300);
            builder.Property(t => t.IsDeleted)
                   .IsRequired();
            builder.HasIndex(t => new { t.Code, t.CreatedBy }).IsUnique();
        }
    }
}
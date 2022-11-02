using CafeStoreManagement.Models;

namespace CafeStoreManagement.ConfigurationModels
{
    public class SizeConfiguration : IEntityTypeConfiguration<SizeModel>
    {
        public void Configure(EntityTypeBuilder<SizeModel> builder)
        {

            builder.ToTable("tblSize");
            builder.Property(t => t.Code)
                    .IsRequired()
                    .HasMaxLength(5);
            builder.Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(t => t.Description)
                   .IsRequired(false)
                   .HasMaxLength(300);
            builder.HasIndex(t => new { t.Code, t.CreatedBy }).IsUnique();
        }
    }
}
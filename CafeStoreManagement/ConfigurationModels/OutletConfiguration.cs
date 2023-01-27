using CafeStoreManagement.Models;

namespace CafeStoreManagement.ConfigurationModels
{
    public class OutletConfiguration : IEntityTypeConfiguration<OutletModel>
    {
        public void Configure(EntityTypeBuilder<OutletModel> builder)
        {

            builder.ToTable("tblOutlet");
            builder.Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(t => t.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);
            builder.Property(t => t.Email)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(t => t.Website)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.Property(t => t.Description)
                   .IsRequired(false)
                   .HasMaxLength(300);
            builder.Property(t => t.IsDeleted)
                   .IsRequired();
        }
    }
}

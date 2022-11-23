using CafeStoreManagement.Models;

namespace CafeStoreManagement.ConfigurationModels
{
    public class PromtionTypeConfiguration : IEntityTypeConfiguration<PromotionTypeModel>
    {
        public void Configure(EntityTypeBuilder<PromotionTypeModel> builder)
        {

            builder.ToTable("tblPromotionType");
            builder.Property(t => t.Code)
                    .IsRequired()
                    .HasMaxLength(5);
            builder.Property(t => t.TypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(t => t.Description)
                   .IsRequired(false)
                   .HasMaxLength(300);
            builder.Property(t => t.IsDeleted)
                   .IsRequired();
            builder.HasIndex(t => new { t.Code, t.CreatedBy }).IsUnique();
        }
    }
}
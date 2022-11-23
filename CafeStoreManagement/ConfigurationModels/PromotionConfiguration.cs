using CafeStoreManagement.Models;

namespace CafeStoreManagement.ConfigurationModels
{
    public class PromotionConfiguration : IEntityTypeConfiguration<PromotionModel>
    {
        public void Configure(EntityTypeBuilder<PromotionModel> builder)
        {

            builder.ToTable("tblPromotion");
            builder.Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(t => t.Description)
                   .IsRequired(false)
                   .HasMaxLength(300);
            builder.Property(t => t.IsDeleted)
                   .IsRequired();
            builder.HasIndex(t => new {t.CreatedBy }).IsUnique();
        }
    }
}
using CafeStoreManagement.Models;

namespace CafeStoreManagement.ConfigurationModels
{
    public class ItemDetailConfiguration : IEntityTypeConfiguration<ItemDetailModel>
    {
        public void Configure(EntityTypeBuilder<ItemDetailModel> builder)
        {

            builder.ToTable("tblItemDetail");
            builder.Property(t => t.Price)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(t => t.Description)
                   .IsRequired(false)
                   .HasMaxLength(300);
            builder.Property(t => t.IsDeleted)
                   .IsRequired();
        }
    }
}
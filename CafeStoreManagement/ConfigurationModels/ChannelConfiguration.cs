using CafeStoreManagement.Models;

namespace CafeStoreManagement.ConfigurationModels
{
    public class ChannelConfiguration : IEntityTypeConfiguration<ChannelModel>
    {
        public void Configure(EntityTypeBuilder<ChannelModel> builder)
        {

            builder.ToTable("tblChannel");
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
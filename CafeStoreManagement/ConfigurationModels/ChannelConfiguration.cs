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
            builder.HasData(
                new ChannelModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "DIN",
                    Abv = "DIN",
                    Name = "Dine In",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = CoreString.user,
                    CreatedDate = DateTime.Now,
                },
                new SourceModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "TAK",
                    Abv = "TAK",
                    Name = "Take Away",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = CoreString.user,
                    CreatedDate = DateTime.Now,
                },
                new SourceModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "DEL",
                    Abv = "DEL",
                    Name = "Delivery",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = CoreString.user,
                    CreatedDate = DateTime.Now,
                }
            );
        }
    }
}
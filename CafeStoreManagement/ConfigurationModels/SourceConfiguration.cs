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

            builder.HasData(
                new SourceModel()
                {
                    Id=Guid.NewGuid(),
                    Code="MBL",
                    Abv="MBL",
                    Name="Mobile App",
                    Description= CoreString.description,
                    IsDeleted=false,
                    CreatedBy= CoreString.user,
                    CreatedDate=DateTime.Now,
                },
                new SourceModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "FAT",
                    Abv = "FAT",
                    Name = "Food Aggregator",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = CoreString.user,
                    CreatedDate = DateTime.Now,
                },
                new SourceModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "WAL",
                    Abv = "WAL",
                    Name = "Walk In",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = CoreString.user,
                    CreatedDate = DateTime.Now,
                }
            );
        }
    }
}
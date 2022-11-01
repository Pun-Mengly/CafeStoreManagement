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
            builder.HasData(
                new SizeModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "S",
                    Name = "Small",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = CoreString.user,
                    CreatedDate = DateTime.Now,
                },
                new SizeModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "M",
                    Name = "Medium",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = CoreString.user,
                    CreatedDate = DateTime.Now,
                },
                new SizeModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "L",
                    Name = "Large",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = CoreString.user,
                    CreatedDate = DateTime.Now,
                }
            );
        }
    }
}
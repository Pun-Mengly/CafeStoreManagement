using CafeStoreManagement.Models;

namespace CafeStoreManagement.ConfigurationModels
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryModel>
    {
        public void Configure(EntityTypeBuilder<CategoryModel> builder)
        {

            builder.ToTable("tblCategory");
            builder.Property(t => t.Code)
                    .IsRequired()
                    .HasMaxLength(5);
            builder.Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(t => t.Description)
                   .IsRequired(false)
                   .HasMaxLength(300);
            builder.Property(t => t.IsDeleted)
                   .IsRequired();

            builder.HasData(
                new CategoryModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "SMT",
                    Name = "Smoothie",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = CoreString.user,
                    CreatedDate = DateTime.Now,
                },
                new CategoryModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "MIT",
                    Name = "Milk Tea",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = CoreString.user,
                    CreatedDate = DateTime.Now,
                },
                new CategoryModel()
                {
                    Id = Guid.NewGuid(),
                    Code = "CAF",
                    Name = "Coffee",
                    Description = CoreString.description,
                    IsDeleted = false,
                    CreatedBy = CoreString.user,
                    CreatedDate = DateTime.Now,
                }
            );
        }
    }
}

using CafeStoreManagement.ConfigurationModels;
using CafeStoreManagement.Models;

public class MenuGroupConfiguration : IEntityTypeConfiguration<MenuGroupModel>
{
    public void Configure(EntityTypeBuilder<MenuGroupModel> builder)
    {
        
        builder.ToTable("tblMenuGroup");
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
               new MenuGroupModel()
               {
                   Id = Guid.NewGuid(),
                   Code = "DRK",
                   Abv = "DRK",
                   Name = "Drink",
                   Description = CoreString.description,
                   IsDeleted = false,
                   CreatedBy = CoreString.user,
                   CreatedDate = DateTime.Now,
               },
               new MenuGroupModel()
               {
                   Id = Guid.NewGuid(),
                   Code = "FOD",
                   Abv = "FOD",
                   Name = "Food",
                   Description = CoreString.description, 
                   IsDeleted = false,
                   CreatedBy = CoreString.user,
                   CreatedDate = DateTime.Now,
               }
               
           );
    }
}


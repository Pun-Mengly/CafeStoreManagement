
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
    }
}






using Microsoft.Extensions.Options;

public class DataContext : IdentityDbContext<IdentityUser> //DBContext
    {
        DbSet<MenuGroupModel> MenuGroups;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CafeStoreManagementDb;Integrated Security=True;TrustServerCertificate=True ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
}


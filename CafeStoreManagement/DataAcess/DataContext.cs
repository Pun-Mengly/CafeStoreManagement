



using CafeStoreManagement.Models;
using Microsoft.Extensions.Options;

public class DataContext : IdentityDbContext<IdentityUser> //DBContext
    {

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
        public DbSet<MenuGroupModel> MenuGroups { get; set; }
        public DbSet<ChannelModel> ChannelModels { get; set; }
        public DbSet<SourceModel> SourceModels { get; set; }
        public DbSet<TaxModel> TaxModels { get; set; }
        public DbSet<ItemDetailModel> ItemDetailModels { get; set; }
        public DbSet<ItemModel> ItemModels { get; set; }
        public DbSet<CategoryModel> CategoryModels { get; set; }
        public DbSet<SizeModel> SizeModels { get; set; }
        //public DbSet<PromotionModel> PromotionModels { get; set; }
        //public DbSet<PromotionTypeModel> PromotionTypeModels { get; set; }
        //public DbSet<PaymentMethodModel> PaymentMethodModels { get; set; }
        //public DbSet<SaleModel> SaleModels { get; set; }
}


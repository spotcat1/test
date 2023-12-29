

using Domain;
using System.Reflection;

namespace Infrastructure.Persistants
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<GenderEntity> Genders { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<UserCompanyJunkEntity> UserCompanies { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema(DomainSchema.schema);
            base.OnModelCreating(modelBuilder);
        }
    }
}

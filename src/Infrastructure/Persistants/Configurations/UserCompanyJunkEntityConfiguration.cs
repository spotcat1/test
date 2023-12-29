
namespace Infrastructure.Persistants.Configurations
{
    internal class UserCompanyJunkEntityConfiguration : IEntityTypeConfiguration<UserCompanyJunkEntity>
    {
        public void Configure(EntityTypeBuilder<UserCompanyJunkEntity> builder)
        {
            builder.ToTable("UserCompany");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsDeleted)
                .IsRequired();


            builder
                .HasOne(x=>x.User)
                .WithMany(x=>x.UserCompanies)
                .HasForeignKey(x=>x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x=>x.Company)
                .WithMany(x=>x.CompanyUsers)
                .HasForeignKey(x=>x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

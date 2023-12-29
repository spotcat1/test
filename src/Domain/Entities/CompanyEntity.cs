

using Domain.Commons;

namespace Domain.Entities
{
    public class CompanyEntity:BaseEntity
    {
        public CompanyEntity()
        {
            CompanyUsers = new List<UserCompanyJunkEntity>();
        }
        public required string Name { get; set; }
        public required string Field { get; set; }
        public required string NumberOfEmployees { get; set; }
        public DateTime CreationDate { get; set; }

        public bool IsDeleted { get; set; } 


        public ICollection<UserCompanyJunkEntity> CompanyUsers { get; set; }
    }
}

using Domain.Commons;


namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity()
        {
            Cars = new List<CarEntity>();
            UserCompanies = new List<UserCompanyJunkEntity>();
        }
        public Guid GenderId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string IdentityCode { get; set; }

        public DateTime BirthDate { get; set; }

        public string? ImagePath { get; set; }

        public string? Nationality {get;set;}

        public bool IsDeleted { get; set; }

        public GenderEntity Gender { get; set; }

        public ICollection<CarEntity> Cars { get; set; }

        public ICollection<UserCompanyJunkEntity> UserCompanies { get; set; }
    }
}

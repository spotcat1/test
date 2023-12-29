
using Domain.Commons;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Domain.Models
{
    public class UserModel:BaseModel
    {
        public UserModel()
        {
            Cars = new List<CarModel>();
            UserCompanies = new List<UserCompanyJunkModel>();
        }
        public Guid GenderId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string IdentityCode { get; set; }

        public DateTime BirthDate { get; set; }

        public IFormFile? ImageFile { get; set; }
        public string? ImagePath { get; set; }

        public string? Nationality { get; set; }

        public bool IsDeleted { get; set; }


        public GenderModel Gender { get; set; }  
        
        public ICollection<CarModel> Cars { get; set; }
        public ICollection<UserCompanyJunkModel> UserCompanies { get; set; }
    }
}

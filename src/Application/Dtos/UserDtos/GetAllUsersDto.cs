

namespace Application.Dtos.UserDtos
{
    public class GetAllUsersDto
    {
        public Guid Id { get; set; }
        public Guid GenderId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string IdentityCode { get; set; }

        public DateTime BirthDate { get; set; }

        public string? ImagePath { get; set; }

        public string? Nationality { get; set; }

        public bool IsDeleted { get; set; }
    }
}

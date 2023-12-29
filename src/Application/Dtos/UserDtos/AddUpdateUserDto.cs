﻿

using Microsoft.AspNetCore.Http;

namespace Application.Dtos.UserDtos
{
    public class AddUpdateUserDto
    {
        public Guid GenderId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string IdentityCode { get; set; }

        public DateTime BirthDate { get; set; }

        public IFormFile? ImageFile { get; set; }

        public string? Nationality { get; set; }

        public bool IsDeleted { get; set; }
    }
}

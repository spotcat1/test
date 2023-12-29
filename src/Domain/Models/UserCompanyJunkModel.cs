﻿
using Domain.Commons;

namespace Domain.Models
{
    public class UserCompanyJunkModel:BaseModel
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }

        public bool IsDeleted { get; set; }

        public UserModel? User { get; set; } 
        public CompanyModel? Company { get; set; }
    }
}

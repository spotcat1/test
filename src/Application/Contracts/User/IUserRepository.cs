
using Application.Dtos.UserDtos;
using Domain.Models;

namespace Application.Contracts.User
{
    public interface IUserRepository
    {
        Task<Guid> AddUser(UserModel userModel);
        Task<string> UpdateUserUser(Guid id, UserModel userModel);

        Task<GetUserByIdDto> GetUserById(Guid id);

        Task<List<GetAllUsersDto>> GetAllUsers(string? FirstFilterOn = null, string? FirstFilterQuery = null,
             string? SecondFilterOn = null, string? SecondFilterQuery = null,
             string? FirstOrderBy = null, bool FirstIsAscending = true,
             string? SecondOrderBy = null, bool SecondIsAscending = true,
             bool ShowDeletedOnes = false,
             int PageNumber = 1, int PageSize = 100);

        Task<string> DeleteUser(Guid id);
        Task<string> SoftDeleteUser(Guid id);

        Task<bool> UserExistance(Guid id);
        Task<bool> GenderExistance(Guid Genderid);
        Task<bool> ReservedIdentityCode(string identityCode,Guid id);


    }
}

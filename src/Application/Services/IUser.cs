

using Application.Dtos.UserDtos;

namespace Application.Services
{
    public interface IUser
    {
        Task<Guid> AddUser(AddUpdateUserDto dto);

        Task<string> UpdateUser(Guid id, AddUpdateUserDto dto);

        Task<GetUserByIdDto> GetUserById(Guid id, bool ShowIfIsDeleted = false);

        Task<List<GetAllUsersDto>> GetAllUsers(string? FirstFilterOn = null, string? FirstFilterQuery = null,
             string? SecondFilterOn = null, string? SecondFilterQuery = null,
             string? FirstOrderBy = null, bool FirstIsAscending = true,
             string? SecondOrderBy = null, bool SecondIsAscending = true,
             bool ShowDeletedOnes=false,
             int PageNumber = 1, int PageSize = 100);

        Task<string> DeleteUser(Guid id);
        Task<string> SoftDeleteUser(Guid id);
    }
}

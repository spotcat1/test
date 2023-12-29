

using Application.Dtos.UserDtos;
using MediatR;

namespace Application.Queries
{
    
    
       public record GetUserByIdQuery(Guid Id, bool ShowIfIsDeleted = false):IRequest<GetUserByIdDto>;

        public record GetAllUsersQuery(string? FirstFilterOn = null, string? FirstFilterQuery = null,
             string? SecondFilterOn = null, string? SecondFilterQuery = null,
             string? FirstOrderBy = null, bool FirstIsAscending = true,
             string? SecondOrderBy = null, bool SecondIsAscending = true,
             bool ShowDeletedOnes = false,
             int PageNumber = 1, int PageSize = 100) :IRequest<List<GetAllUsersDto>>;
    
}

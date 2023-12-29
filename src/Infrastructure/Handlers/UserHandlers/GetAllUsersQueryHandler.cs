﻿

using Application.Dtos.UserDtos;

using Application.Queries;
using Application.Services;
using MediatR;

namespace Infrastructure.Handlers.UserHandlers
{
    internal class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<GetAllUsersDto>>
    {
        private readonly IUser _user;

        public GetAllUsersQueryHandler(IUser user)
        {
            _user = user;
        }
        public async Task<List<GetAllUsersDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _user.GetAllUsers(request.FirstFilterOn, request.FirstFilterQuery,
            request.SecondFilterOn, request.SecondFilterQuery,
            request.FirstOrderBy, request.FirstIsAscending,
            request.SecondOrderBy, request.SecondIsAscending, request.ShowDeletedOnes,
            request.PageNumber, request.PageSize);
        }
    }
}

using Application.Dtos.UserDtos;
using Application.Queries;
using Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Handlers.UserHandlers
{
    internal class GetUserByIdQueryHandler:IRequestHandler<GetUserByIdQuery,GetUserByIdDto>
    {
        private readonly IUser _user;

        public GetUserByIdQueryHandler(IUser user)
        {
            _user = user;
        }

        public async Task<GetUserByIdDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _user.GetUserById(request.Id,request.ShowIfIsDeleted);
        }
    }
}

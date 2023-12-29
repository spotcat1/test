using Application.Commands;
using Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Handlers.UserHandlers
{
    internal class DeleteUserHandler : IRequestHandler<DeleteUserCommand, string>
    {
        private readonly IUser _user;

        public DeleteUserHandler(IUser user)
        {
            _user = user;
        }
        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _user.DeleteUser(request.Id);
        }
    }
}

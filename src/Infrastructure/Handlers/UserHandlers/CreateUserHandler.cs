using Application.Commands;
using Application.Services;
using MediatR;

namespace Infrastructure.Handlers.UserHandlers
{
    internal class CreateUserHandler : IRequestHandler<AddUserCommand, Guid>
    {
        private readonly IUser _user;

        public CreateUserHandler(IUser user)
        {
            _user = user;
        }

        public async Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            return await _user.AddUser(request.dto);
        }
    }
}

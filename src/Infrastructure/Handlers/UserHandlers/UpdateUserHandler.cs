

using Application.Commands;
using Application.Services;
using MediatR;


namespace Infrastructure.Handlers.UserHandlers
{
    internal class UpdateUserHandler : IRequestHandler<UpdateUserCommand, string>
    {
        private readonly IUser _user;

        public UpdateUserHandler(IUser user)
        {
            _user = user;
        }
        public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _user.UpdateUser(request.id,request.dto);
        }
    }
}

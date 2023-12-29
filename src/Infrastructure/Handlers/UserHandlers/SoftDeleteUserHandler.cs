using Application.Commands;
using Application.Services;
using MediatR;


namespace Infrastructure.Handlers.UserHandlers
{
    internal class SoftDeleteUserHandler:IRequestHandler<SoftDeleteUserCommand,string>
    {
        private readonly IUser _user;

        public SoftDeleteUserHandler(IUser user)
        {
            _user = user;
        }

        public async Task<string> Handle(SoftDeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _user.SoftDeleteUser(request.Id);
        }
    }
}

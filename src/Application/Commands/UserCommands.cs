
using Application.Dtos.UserDtos;
using MediatR;

namespace Application.Commands
{
   
    
        public record AddUserCommand(AddUpdateUserDto dto):IRequest<Guid>;
        public record UpdateUserCommand(Guid id,AddUpdateUserDto dto):IRequest<string>;
        public record DeleteUserCommand(Guid Id):IRequest<string>;
        public record SoftDeleteUserCommand(Guid Id):IRequest<string>;
    
}

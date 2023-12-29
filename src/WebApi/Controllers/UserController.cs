using Application.Commands;
using Application.Contracts.User;
using Application.Dtos.UserDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Filter;

namespace WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    [CustomActionResultFilter]
    [ExceptionFilter]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediatR;

        public UserController(IUserRepository userRepository, IMediator mediatR)
        {
            _userRepository = userRepository;
            _mediatR = mediatR;
        }

  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Guid>> CreateUserV1([FromForm] AddUpdateUserDto dto)
        {
            var GenderExistance =await _userRepository.GenderExistance(dto.GenderId);

            var ReservedIdentityCode =await _userRepository.ReservedIdentityCode(dto.IdentityCode, Guid.Empty);

            if (GenderExistance && !ReservedIdentityCode)
            {
                var Result = await _mediatR.Send(new AddUserCommand(dto));
                return Ok(Result);
            }

            return Guid.Empty;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<string>> UpdateUserV1([FromRoute] Guid id, [FromForm] AddUpdateUserDto dto)
        {
            throw new NotFiniteNumberException();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<GetUserByIdDto>> GetUserByIdV1([FromRoute] Guid id, bool ShoIfIsDeleted)
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<List<GetAllUsersDto>>> GetAllUsersV1([FromQuery] string? FirstFilterOn, [FromQuery] string? FirstFilterQuery,
            [FromQuery] string? SecondFilterOn, [FromQuery] string? SecondFilterQuery,
            [FromQuery] string? FirstOrderBy, [FromQuery] bool? FirstIsAscending,
            [FromQuery] string? SecondOrderBy, [FromQuery] bool? SecondIsAscending,
            [FromQuery] bool? ShowDeletedOnes,
            [FromQuery] int PageNumber = 1, [FromQuery] int PageSize = 100)
        {
            throw new NotImplementedException();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> DeleteUserV1([FromRoute]Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<string>> SoftDeleteUserV1([FromRoute]Guid id)
        {
            throw new NotImplementedException();
        }


    }
}

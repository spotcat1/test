using Application.Contracts.User;
using Application.Dtos.UserDtos;
using Application.Exceptions;
using Domain.Models;
using FluentValidation;

namespace Application.Services
{
    public class User : IUser
    {
        private readonly IValidator<AddUpdateUserDto> _validator;
        private readonly IUserRepository _userRepository;


        public User(IValidator<AddUpdateUserDto> validator, IUserRepository userRepository)
        {
            _validator = validator;
            _userRepository = userRepository;
        }
        public async Task<Guid> AddUser(AddUpdateUserDto dto)
        {
            dto.FirstName = RemoveSapces(dto.FirstName);
            dto.LastName = RemoveSapces(dto.LastName);
            dto.IdentityCode = RemoveSapces(dto.IdentityCode);

            if (dto.Nationality != null)
            {
                dto.Nationality = RemoveSapces(dto.Nationality);
            }

            var ValidationResult = _validator.Validate(dto);

            if (!ValidationResult.IsValid)
            {
                throw new CustomValidationException(ValidationResult.Errors);
            }


            var UserModelInstance = new UserModel
            {
                GenderId = dto.GenderId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                IdentityCode = dto.IdentityCode,
                BirthDate = dto.BirthDate,
                ImageFile = dto.ImageFile,
                Nationality = dto.Nationality,
                IsDeleted = dto.IsDeleted,
            };


            //Implement the Logic If Needed


            return await _userRepository.AddUser(UserModelInstance);
        }



        public Task<string> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllUsersDto>> GetAllUsers(string? FirstFilterOn = null, string? FirstFilterQuery = null, string? SecondFilterOn = null, string? SecondFilterQuery = null, string? FirstOrderBy = null, bool FirstIsAscending = true, string? SecondOrderBy = null, bool SecondIsAscending = true, bool ShowDeletedOnes = false, int PageNumber = 1, int PageSize = 100)
        {
            throw new NotImplementedException();
        }

        public async Task<GetUserByIdDto> GetUserById(Guid id, bool ShowIfIsDeleted = false)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SoftDeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateUser(Guid id, AddUpdateUserDto dto)
        {
            throw new NotImplementedException();
        }



        private string RemoveSapces(string input)
        {
            return input.Replace(" ", "");
        }
    }
}

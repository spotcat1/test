using Application.Contracts.User;
using Application.Dtos.UserDtos;
using Application.Exceptions;
using AutoMapper;
using Domain.Models;
using Infrastructure.Persistants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;
using System.IO;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHost;
        private const string ImagePath = "Images/User";
        private readonly IHttpContextAccessor _httpcontext;


        public UserRepository(ApplicationDbContext context, IMapper mapper, IWebHostEnvironment webHost,
            IHttpContextAccessor httpcontext)
        {
            _context = context;
            _mapper = mapper;
            _webHost = webHost;
            _httpcontext = httpcontext;
        }

        public async Task<Guid> AddUser(UserModel userModel)
        {
            var UploadRootPath = Path.Combine(_webHost.WebRootPath, ImagePath);

            if (!Directory.Exists(UploadRootPath))
            {
                Directory.CreateDirectory(UploadRootPath);
            }

            if (userModel.ImageFile != null)
            {
                var fileExtension = Path.GetExtension(userModel.ImageFile.FileName);
                var AllowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                if (!AllowedExtensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase))
                {

                    userModel.ImageFile = null;

                }



            }

            var entity = _mapper.Map<UserEntity>(userModel);

            if (userModel.ImageFile != null && userModel.ImageFile.Length > 0)
            {
                var FileExtension = Path.GetExtension(userModel.ImageFile.FileName);
                var NewFileName = $"User_{Guid.NewGuid().ToString().Replace("-", "")}{FileExtension}";
                var FilePatth = Path.Combine(UploadRootPath, NewFileName);
                using (var FileStream = new FileStream(FilePatth,FileMode.Create))
                {
                    await userModel.ImageFile.CopyToAsync(FileStream).ConfigureAwait(false);
                }

                entity.ImagePath = $"{ImagePath}/{NewFileName}";
            }

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;



        }



        public async Task<string> UpdateUserUser(Guid id, UserModel userModel)
        {
            throw new NotImplementedException();
        }











        public async Task<string> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }






        public async Task<List<GetAllUsersDto>> GetAllUsers(string? FirstFilterOn = null, string? FirstFilterQuery = null, string? SecondFilterOn = null, string? SecondFilterQuery = null, string? FirstOrderBy = null, bool FirstIsAscending = true, string? SecondOrderBy = null, bool SecondIsAscending = true, bool ShowDeletedOnes = false, int PageNumber = 1, int PageSize = 100)
        {
            throw new NotImplementedException();
        }

        public async Task<GetUserByIdDto> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SoftDeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

     

        public async Task<bool> UserExistance(Guid id)
        {
            var Result = await _context.Users.AnyAsync(x => x.Id == id && !x.IsDeleted);

            if (!Result)
            {
                throw new NotFoundException("کاربر یافت نشد");
            }

            return true;
        }

        public async Task<bool> GenderExistance(Guid Genderid)
        {
            var Result = await _context.Genders.AnyAsync(x => x.Id == Genderid && !x.IsDeleted);

            if (!Result)
            {
                throw new NotFoundException("شناسه جنسیت نامعتبر است");
            }

            return true;
        }

        public async Task<bool> ReservedIdentityCode(string identityCode, Guid id)
        {
            var Result = await _context.Users.AnyAsync(x => x.IdentityCode == identityCode && !x.IsDeleted && x.Id != id);

            if (Result)
            {
                throw new NotFoundException("کد ملی متعلق به شخص دیگری است");
            }

            return false;
        }
    }
}

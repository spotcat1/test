using Application.Dtos.UserDtos;
using FluentValidation;


namespace Infrastructure.CrossCuttings.Validations.UserValidations
{
    public class UserValidator : AbstractValidator<AddUpdateUserDto>
    {
        public UserValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;


            RuleFor(x => x.GenderId)
                .NotEmpty()
                .WithName("شناسه جنسیت");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50)
                .Matches("^[آ-یA-Z-az]*$")
                .WithName("نام");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50)
                .Matches("^[آ-یA-Z-az]*$")
                .WithName("نام خانوادگی");

            RuleFor(x => x.IdentityCode)
                .NotEmpty()
                .Length(11)
                .Matches("^[0-9]*$")
                .WithName("کد ملی");

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .Must(ValidateBirthDate)
                .WithName("تاریخ تولد");

            RuleFor(x => x.Nationality)
                .MaximumLength(50)
                .Matches("^[آ-یA-Z-az]*$")
                .WithName("ملیت");


        }




        private bool ValidateBirthDate(DateTime birthDate)
        {

            bool IsValid = birthDate.Year >= 1800 && birthDate.Year <= DateTime.Now.Year &&
                   birthDate.Month >= 1 && birthDate.Month <= 12 &&
                   birthDate.Day >= 1 && birthDate.Day <= 30;

            return IsValid;
        }
    }
}

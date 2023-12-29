

namespace Infrastructure.CrossCuttings.Validations.UserValidations
{
    public class UserValidatorCustomLanguage:FluentValidation.Resources.LanguageManager
    {
        public UserValidatorCustomLanguage()
        {
            Culture = new System.Globalization.CultureInfo("fa-IR");

            AddTranslation("fa", "NotEmptyValidator", "{PropertyName}   الزامی میباشد ");
            AddTranslation("fa", "MaximumLengthValidator", "{PropertyName} بیش از حد مشخص شده است  طول ");
            AddTranslation("fa", "RegularExpressionValidator", "{PropertyName}  باید فقط حاوی حروف باشد ");
            AddTranslation("fa", "RegularExpressionValidator", "{PropertyName}   باید فقط حاوی ارقام باشد ");
        }
    }
}

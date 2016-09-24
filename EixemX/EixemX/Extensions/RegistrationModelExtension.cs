using System.Linq;
using EixemX.Localization;
using EixemX.Services.Account;

namespace EixemX.Extensions
{
    public static class RegistrationModelExtension
    {
        public static string GetErrorMessage(this RegistrationModel model)
        {
            string result = string.Empty;
            var errorType = model.GetErrorTypes().FirstOrDefault();
            switch (errorType)
            {
                case RegistrationModelErrorType.EmainInvalid:
                    result = TextResources.Alert_Registration_EmainInvalid;
                    break;
                case RegistrationModelErrorType.BirthdayInvalid:
                    result = TextResources.Alert_Registration_BirthdayInvalid;
                    break;
                case RegistrationModelErrorType.LastnameInvalid:
                    result = TextResources.Alert_Registration_LastnameInvalid;
                    break;
                case RegistrationModelErrorType.FirstnameInvalid:
                    result = TextResources.Alert_Registration_FirstnameInvalid;
                    break; 
                case RegistrationModelErrorType.PasswordInvalid: 
                case RegistrationModelErrorType.PasswordConfirmationInvalid:
                    result = TextResources.Alert_Registration_PasswordInvalid;
                    break;
                case RegistrationModelErrorType.PasswordNotMatch:
                    result = TextResources.Alert_Registration_PasswordNotMatch;
                    break; 
            }
            return result;
        }
    }
}
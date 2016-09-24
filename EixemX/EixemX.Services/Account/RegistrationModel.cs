using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EixemX.Services.Base;

namespace EixemX.Services.Account
{
    public class RegistrationModel : BaseModel
    {
        public string Email { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Birthday { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }

        public bool IsValid()
        {
            return !GetErrorTypes().Any(); 

        }

        public List<RegistrationModelErrorType> GetErrorTypes()
        {
            List<RegistrationModelErrorType> result = new List<RegistrationModelErrorType>();

            if (string.IsNullOrWhiteSpace(Email))
            {
                result.Add(RegistrationModelErrorType.EmainInvalid);
            }
            if (string.IsNullOrWhiteSpace(Lastname))
            {
                result.Add(RegistrationModelErrorType.LastnameInvalid);
            }
            if (string.IsNullOrWhiteSpace(Firstname))
            {
                result.Add(RegistrationModelErrorType.FirstnameInvalid);
            }
            if (string.IsNullOrWhiteSpace(Birthday))
            {
                result.Add(RegistrationModelErrorType.BirthdayInvalid);
            }
            if (string.IsNullOrWhiteSpace(Password))
            {
                result.Add(RegistrationModelErrorType.PasswordInvalid);
            }
            if (string.IsNullOrWhiteSpace(PasswordConfirmation))
            {
                result.Add(RegistrationModelErrorType.PasswordConfirmationInvalid);
            }
             if (!string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(PasswordConfirmation) && !Password.Equals(PasswordConfirmation))
            {
                result.Add(RegistrationModelErrorType.PasswordNotMatch);
            }
            return result;
        }

        private bool HasError(params RegistrationModelErrorType[] errors)
        {
            return GetErrorTypes().Any(errors.Contains);
        }

        public bool IsValidMandatory()
        {
            return !HasError(RegistrationModelErrorType.EmainInvalid, RegistrationModelErrorType.BirthdayInvalid, 
                RegistrationModelErrorType.FirstnameInvalid,RegistrationModelErrorType.LastnameInvalid);
        }

        public bool IsValidPassword()
        {
            return !HasError(RegistrationModelErrorType.PasswordInvalid);
        }
    }

    public enum RegistrationModelErrorType
    {
        None,
        PasswordNotMatch,
        EmainInvalid,
        PasswordInvalid,
        PasswordConfirmationInvalid,
        LastnameInvalid,
        FirstnameInvalid,
        BirthdayInvalid
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EixemX.Services.Account;
using EixemX.Services.Authentication;
using EixemX.ViewModels.Home;

namespace EixemX.Services.Authentication
{
    public class AuthenticationDemoService : IAuthenticationService
    {
        internal class AuthenticationDemoResult
        {
            public string Email { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string Note { get; set; }
        }

        private const string EmailDemo = "demo@eixem.com";
        private const string PasswordDemo = "demo";

        private AuthenticationDemoResult GetDemoAuthentication(string message)
        {
            return new AuthenticationDemoResult
            {
                Email = "doctor.who@eixem.com",
                Firstname = "Doctor",
                Lastname = "Who",
                Note = message
            };
        }

        private AuthenticationDemoResult AuthenticationResult { get; set; }


        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            //Server call simulation
            await Task.Delay(2000);
            AuthenticationResult = null;

            if (!string.IsNullOrEmpty(email) && 
                email.Equals(EmailDemo, StringComparison.CurrentCultureIgnoreCase) &&
                !string.IsNullOrEmpty(password) &&
                password.Equals(PasswordDemo, StringComparison.CurrentCultureIgnoreCase))
            {
                AuthenticationResult = GetDemoAuthentication("AuthenticationDemoService AuthenticateAsync");
            }

            return IsAuthenticated;
        } 

        public async Task<bool> LogoutAsync()
        {
            return true;
        }

        public async Task<string> GetTokenAsync()
        {
            return "";
        }

        public bool IsAuthenticated
        {
            get { return AuthenticationResult != null; }
        } 

        public async Task<bool> RegisterAsync(RegistrationModel model)
        {
            //Server call simulation
            await Task.Delay(2000);
             
            var result = model.IsValid();
            
            if (result)
            {
                model.Email = EmailDemo;
                model.Password = PasswordDemo;
            }

            return result;
        }

        public async Task<bool> PasswordForgetAsync(string email)
        { 
            //Server call simulation
            await Task.Delay(2000);
             
            if (!string.IsNullOrWhiteSpace(email) && email.Equals(EmailDemo, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public async Task<UserAccountModel> GetUserAccount()
        { 
            var result = new UserAccountModel();

            result.Borrow.AddBorrow(35.04, 543, DateTime.Now.AddDays(20));
            result.Borrow.DateNextRefound = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 5); 

            result.Interest.AddInterest(106.59);
            result.Loan.AddLoan(15.67);
            result.User.Update(new UserDetailModel
            {
                Address = new UserAddressModel
                {
                   Address = "177 boulevard du Président Wilson",
                   City = "Bordeaux",
                   Country = "France",
                   PostalCode = "33300"
                },
                Bank = new UserBankModel
                {
                    BankCode = "ING",
                    CardNumber = "XXXX XXXX XXXX X720",
                    CardExpiredDate = DateTime.Now.AddDays(10).AddMonths(5),
                    Iban = "INGGB76 XXX XXX XXX 5686",
                    BankName = "LLOYDS BANK"
                }, 
                Finance = new UserFinanceModel
                {
                    Amount = 1500
                },
                
                Firstname = "Marc",
                Lastname = "Durand",
                DateInscription = DateTime.Now.AddDays(-10),
                Email = "demo@eixem.com",
                DateBirth = DateTime.Now.AddYears(-25).AddDays(15)
            });

            return result;
        }
    }
}

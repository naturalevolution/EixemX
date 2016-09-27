using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EixemX.Services.Account;
using EixemX.Services.Authentication;
 
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

        private const string EmailDemo = "demo";
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
    }
}

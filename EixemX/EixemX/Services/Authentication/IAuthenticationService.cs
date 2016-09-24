﻿using System.Threading.Tasks;
using EixemX.Services.Account;

namespace EixemX.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string email, string password);

        Task<bool> LogoutAsync();

        Task<string> GetTokenAsync();

        bool IsAuthenticated { get; }
         
        Task<bool> RegisterAsync(RegistrationModel model);
    }
}

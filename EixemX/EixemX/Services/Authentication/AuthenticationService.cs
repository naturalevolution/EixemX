﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EixemX.Services.Account;
using EixemX.Services.Authentication;
using EixemX.Services.Config;
using EixemX.ViewModels.Home;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;
using Microsoft.Azure.ActiveDirectory.GraphClient;
 
namespace EixemX.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        string _AzureAuthenticationClientId;
        string _AzureGraphApiClientId;
        string _TenantAuthority;
        string _ReturnUri;
        string _ResourceUri;

        readonly IAuthenticator _Authenticator;

        readonly IConfigFetcher _ConfigFetcher;

        AuthenticationResult _AuthenticationResult;

        public AuthenticationService()
        {
            _ConfigFetcher = DependencyService.Get<IConfigFetcher>();

            _Authenticator = DependencyService.Get<IAuthenticator>();
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            await GetConfigAsync();

            // prompts the user for authentication
            _AuthenticationResult = await _Authenticator.Authenticate(_TenantAuthority, _ResourceUri, _AzureAuthenticationClientId, _ReturnUri);

            var accessToken = await GetTokenAsync();

            // instantiate an ActiveDirectoryClient to query the Graph API
            var activeDirectoryGraphApiClient = new ActiveDirectoryClient(
                new Uri(new Uri(_ResourceUri), _AzureGraphApiClientId),
                () => Task.FromResult<string>(accessToken)
            );

            return true;
        }

        public async Task<bool> LogoutAsync()
        {
            await GetConfigAsync();

            await Task.Factory.StartNew(async () =>
            {
                var success = await _Authenticator.DeAuthenticate(_TenantAuthority);
                if (!success)
                {
                    throw new Exception("Failed to DeAuthenticate!");
                }
                _AuthenticationResult = null;
            });
            return true;
        }

        public async Task<string> GetTokenAsync()
        {
            await GetConfigAsync();

            return await _Authenticator.FetchToken(_TenantAuthority);
        }

        public bool IsAuthenticated
        {
            get
            {
                if (_AuthenticationBypassed)
                    return true;
                else
                    return _AuthenticationResult != null;
            }
        }

        public Task<bool> RegisterAsync(RegistrationModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PasswordForgetAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserAccountModel> GetUserAccount()
        {
            throw new NotImplementedException();
        }

        bool _AuthenticationBypassed;
        /// <summary>
        /// Used only for demo, to quickly bypass actual authentication
        /// </summary>
        /// <returns>Task</returns>
        public void BypassAuthentication()
        {
            _AuthenticationBypassed = true;
        }

        async Task GetConfigAsync()
        {
            if (_AzureAuthenticationClientId == null)
                _AzureAuthenticationClientId = await _ConfigFetcher.GetAsync("azureActiveDirectoryAuthenticationClientId", true);

            if (_AzureGraphApiClientId == null)
                _AzureGraphApiClientId = await _ConfigFetcher.GetAsync("azureActiveDirectoryGraphApiClientId", true);

            if (_TenantAuthority == null)
                _TenantAuthority = await _ConfigFetcher.GetAsync("azureActiveDirectoryAuthenticationTenantAuthorityUrl");

            if (_ReturnUri == null)
                _ReturnUri = await _ConfigFetcher.GetAsync("azureActiveDirectoryAuthenticationReturnUri");

            if (_ResourceUri == null)
                _ResourceUri = await _ConfigFetcher.GetAsync("azureActiveDirectoryAuthenticationResourceUri");
        }
    }
}

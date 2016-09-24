using System;
using EixemX.Factories;
using EixemX.Pages.Authentication;
using EixemX.ViewModels.Base;
using Xamarin.Forms;

namespace EixemX.ViewModels.Authentication
{
    public class RegistrationViewModel : BaseViewModel
    {
        public RegistrationViewModel(INavigation navigation) : base(navigation)
        {
            
        }
        private string _birthday;
        private string _email;
        private string _firstname;
        private string _lastname;

        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                SetProperty(ref _lastname, value, "Lastname");
            }
        }

        public string Firstname
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                SetProperty(ref _lastname, value, "Firstname");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                SetProperty(ref _lastname, value, "Email");
            }
        }

        public string Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                SetProperty(ref _birthday, value, "Birthday");
            }
        }

        public async void NextClicked(object sender, EventArgs e)
        {
            LogDebug("NextClicked");
            await PushAsync(new RegistrationPasswordPage());
            buttonFactory.SetToDefault(sender as Button, ButtonStyle.Transparent);
        }


        public async void BackButtonClicked(object sender, EventArgs e)
        {
            LogDebug("BackButtonClicked");
            await PopAsync();
        }

        public async void BackBarButtonClicked(object sender, EventArgs e)
        {
            LogDebug("BackBarButtonClicked");
            await PopAsync();
            buttonFactory.SetToDefault(sender as Button, ButtonStyle.White);
        }
    }
}
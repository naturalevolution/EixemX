using EixemX.Pages.Base;
using EixemX.ViewModels.Authentication;
using Xamarin.Forms;

namespace EixemX.Pages.Authentication
{
    public class RegistrationPage : ModelBoundContentPage<RegistrationViewModel>
    {
        public RegistrationPage()
        {
            BindingContext = new RegistrationViewModel();

            BackgroundColor = Color.Blue;
        }
    }
}
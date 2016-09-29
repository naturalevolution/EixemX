using EixemX.Factories;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageFactory))]

namespace EixemX.Factories
{
    public class ImageFactory : IImageFactory
    {
        private const string ArrowLeftPicture = "arrow_left.png";
        private const string ArrowRightPicture = "arrow_right.png";
         
        public const string SreenBackgroundGreen = "screen_bg.png";
        public const string LogoWhiteTransparent = "logo_white.png";
        public const string NavigationLogoIcon = "logo_green.png";
        public const string IconNavigation = "nav_icon.png";
        public const string IconAccount = "account_icon.png";

        public const string NavigationMenuIcon = "nav_icon.png";
        public const string NavigationAccountIcon = "account_icon.png";
        public const string NavigationMenuBackgroundIcon = "nav_bg.jpg";

        public const string MenuHistory = "history_icon.png";
        public const string MenuEmprunter = "emprunter_icon.png";
        public const string MenuPreter = "preter_icon.png";
        public const string MenuPayer = "payer_icon.png";
        public const string MenuRetirer = "retirer_icon.png";
        public const string MenuAbout = "about_icon.png";
        public const string MenuContact = "contact_icon.png";
        public const string MenuProfessional = "professional_icon.png";

        public const string MenuPreterSelected = "preter_icon_white.png";
        public const string MenuRetirerSelected = "retirer_icon_white.png";
        public const string MenuEmprunterSelected = "emprunter_icon_white.png";
        public const string MenuHistorySelected = "history_icon_white.png";
        public const string MenuAboutSelected = "about_icon_white.jpg";
        public const string MenuContactSelected = "contact_icon_white.jpg";
        public const string MenuProfessionalSelected = "professional_icon_white.png";
        public const string MenuPayerSelected = "payer_icon_white.png";
        

public FileImageSource GreenLogoFileImage()
        {
            return new FileImageSource {File = NavigationLogoIcon};
        }

        public FileImageSource NavigationIcon()
        {
            return new FileImageSource {File = IconNavigation};
        }

        public FileImageSource AccountIcon()
        {
            return new FileImageSource {File = IconAccount};
        }

        public FileImageSource HistoryPageIcon()
        {
            return new FileImageSource {File = MenuHistory};
        }

        public FileImageSource EmprunterPageIcon()
        {
            return new FileImageSource {File = MenuEmprunter};
        }

        public FileImageSource PreterPageIcon()
        {
            return new FileImageSource {File = MenuPreter};
        }

        public FileImageSource PayerPageIcon()
        {
            return new FileImageSource {File = MenuPayer};
        }

        public FileImageSource RetirerPageIcon()
        {
            return new FileImageSource {File = MenuRetirer};
        }

        public FileImageSource AboutPageIcon()
        {
            return new FileImageSource {File = MenuAbout};
        }

        public FileImageSource ProfessionalPageIcon()
        {
            return new FileImageSource {File = MenuProfessional};
        }

        public FileImageSource ContactPageIcon()
        {
            return new FileImageSource {File = MenuContact};
        }

        public Image NavigationLogo()
        {
            return new Image
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Source = ImageSource.FromFile(NavigationLogoIcon)
            };
        }

        public Image NavigationMenu()
        {
            return new Image
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Source = ImageSource.FromFile(NavigationMenuIcon)
            };
        }

        public Image NavigationAccount()
        {
            return new Image
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Source = ImageSource.FromFile(NavigationAccountIcon)
            };
        }

        public FileImageSource NavigationMenuBackground()
        { 
            return new FileImageSource { File = NavigationMenuBackgroundIcon };
        }

        public ImageSource ArrowLeft()
        {
            return ImageSource.FromFile(ArrowLeftPicture);
        }

        public ImageSource ArrowRight()
        {
            return ImageSource.FromFile(ArrowRightPicture);
        }

        public Image WhiteLogo()
        {
            return new Image
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Source = ImageSource.FromFile(LogoWhiteTransparent)
            };
        }

        public Image WhiteLogoSmall()
        {
            var result = WhiteLogo();
            result.WidthRequest = 130;
            result.Aspect = Aspect.AspectFit;
            return result;
        }
    }

    public interface IImageFactory
    {
        Image WhiteLogo();
        Image WhiteLogoSmall();
        FileImageSource GreenLogoFileImage();
        FileImageSource NavigationIcon();
        FileImageSource AccountIcon();
        FileImageSource HistoryPageIcon();
        FileImageSource EmprunterPageIcon();
        FileImageSource PreterPageIcon();
        FileImageSource PayerPageIcon();
        FileImageSource RetirerPageIcon();
        FileImageSource AboutPageIcon();
        FileImageSource ProfessionalPageIcon();
        FileImageSource ContactPageIcon();
        Image NavigationLogo();
        Image NavigationMenu();
        Image NavigationAccount();
        FileImageSource NavigationMenuBackground();
        ImageSource ArrowLeft(); 
        ImageSource ArrowRight();
    }
}
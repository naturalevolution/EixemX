using System;
using EixemX.Factories;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageFactory))]

namespace EixemX.Factories
{
    public class ImageFactory : IImageFactory
    {
        public const string LogoWhiteTransparent = "logo_white.png";
        public const string NavigationLogoIcon = "logo_green.png";
        public const string IconNavigation = "nav_icon.png";
        public const string IconAccount = "account_icon.png";
        public const string IconHistory = "history_icon.png";
        public const string IconEmprunter = "emprunter_icon.png";
        public const string IconPreter = "preter_icon.png";
        public const string IconPayer = "payer_icon.png";
        public const string IconRetirer = "retirer_icon.png";
        public const string IconAbout = "about_icon.png";
        public const string IconContact = "contact_icon.png";
        public const string IconProfessional = "professional_icon.png";
        private const string NavigationMenuIcon = "nav_icon.png";
        private const string NavigationAccountIcon = "account_icon.png";

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
            return new FileImageSource {File = IconHistory};
        }

        public FileImageSource EmprunterPageIcon()
        {
            return new FileImageSource {File = IconEmprunter};
        }

        public FileImageSource PreterPageIcon()
        {
            return new FileImageSource {File = IconPreter};
        }

        public FileImageSource PayerPageIcon()
        {
            return new FileImageSource {File = IconPayer};
        }

        public FileImageSource RetirerPageIcon()
        {
            return new FileImageSource {File = IconRetirer};
        }

        public FileImageSource AboutPageIcon()
        {
            return new FileImageSource {File = IconAbout};
        }

        public FileImageSource ProfessionalPageIcon()
        {
            return new FileImageSource {File = IconProfessional};
        }

        public FileImageSource ContactPageIcon()
        {
            return new FileImageSource { File = IconContact };
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
    }
}
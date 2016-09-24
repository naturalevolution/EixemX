using EixemX.Constants;
using EixemX.Factories;
using Xamarin.Forms;
using XLabs.Forms.Controls;

[assembly: Xamarin.Forms.Dependency(typeof(ImageFactory))]
namespace EixemX.Factories
{
    public class ImageFactory : IImageFactory
    {
        private const string LogoWhiteTransparent = "logo_white.png";

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
    }
}
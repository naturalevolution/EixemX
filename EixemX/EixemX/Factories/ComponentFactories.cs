using Xamarin.Forms;

namespace EixemX.Factories
{
    public static class ComponentFactories
    {
        public static IButtonFactory Buttons
        {
            get { return DependencyService.Get<IButtonFactory>(); }
        }

        public static IEntryFactory Entries
        {
            get { return DependencyService.Get<IEntryFactory>(); }
        }

        public static IImageFactory Images
        {
            get { return DependencyService.Get<IImageFactory>(); }
        }

        public static ILabelFactory Labels
        {
            get { return DependencyService.Get<ILabelFactory>(); }
        }

        public static ILayoutFactory Layouts
        {
            get { return DependencyService.Get<ILayoutFactory>(); }
        }
    }
}
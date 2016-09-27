using EixemX.Factories;
using EixemX.ViewModels.Base;
using Xamarin.Forms;

namespace EixemX.Pages.Base
{
    /// <summary>
    /// A generically typed ContentPage that enforces the type of its BindingContext according to TViewModel.
    /// </summary>
    public abstract class ModelBoundContentPage<TViewModel> : ContentPage where TViewModel : BaseViewModel
    {

        protected IButtonFactory buttonFactory;
        protected ILayoutFactory layoutFactory;
        protected IImageFactory imageFactory;
        protected IStyleFactory styleFactory;
        protected IEventFactory eventFactory;
        protected IEntryFactory entryFactory;
        protected ILabelFactory labelFactory;

        protected ModelBoundContentPage()
        {
            buttonFactory = DependencyService.Get<IButtonFactory>();
            imageFactory = DependencyService.Get<IImageFactory>();
            layoutFactory = DependencyService.Get<ILayoutFactory>();
            styleFactory = DependencyService.Get<IStyleFactory>();
            eventFactory = DependencyService.Get<IEventFactory>();
            entryFactory = DependencyService.Get<IEntryFactory>();
            labelFactory = DependencyService.Get<ILabelFactory>();
        }


        /// <summary>
        /// Gets the generically typed ViewModel from the underlying BindingContext.
        /// </summary>
        /// <value>The generically typed ViewModel.</value>
        protected TViewModel ViewModel
        {
            get { return base.BindingContext as TViewModel; }
        }

        /// <summary>
        /// Sets the underlying BindingContext as the defined generic type.
        /// </summary>
        /// <value>The generically typed ViewModel.</value>
        /// <remarks>Enforces a generically typed BindingContext, instead of the underlying loosely object-typed BindingContext.</remarks>
        public new TViewModel BindingContext
        {
            set
            {
                base.BindingContext = value;
                base.OnPropertyChanged("BindingContext");
            }
        }
         
        protected void LogDebug(string message)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(">>>>>> DEBUG : {0} : {1}", message, GetType().FullName));
        }

        protected Label GetMessageLabel()
        { 
            var result = labelFactory.LabelMessage();
            result.SetBinding(Label.TextProperty, "DisplayMessage", BindingMode.TwoWay);
            return result;
        }

        protected override void OnAppearing()
        {
            LogDebug("OnAppearing");
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
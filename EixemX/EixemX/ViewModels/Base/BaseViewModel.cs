using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using EixemX.Factories;
using EixemX.Services.Account;
using EixemX.Services.Authentication;
using EixemX.Services.Config;
using EixemX.ViewModels.Home;
using Xamarin.Forms;

namespace EixemX.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        ///     Gets or sets the "IsBusy" property
        /// </summary>
        /// <value>The isbusy property.</value>
        public const string CanLoadMorePropertyName = "CanLoadMore";

        /// <summary>
        ///     Gets or sets the "IsBusy" property
        /// </summary>
        /// <value>The isbusy property.</value>
        public const string IsBusyPropertyName = "IsBusy";

        /// <summary>
        ///     Gets or sets the "Title" property
        /// </summary>
        /// <value>The title.</value>
        public const string TitlePropertyName = "Title";

        /// <summary>
        ///     Gets or sets the "Subtitle" property
        /// </summary>
        public const string SubtitlePropertyName = "Subtitle";

        /// <summary>
        ///     Gets or sets the "Icon" of the viewmodel
        /// </summary>
        public const string IconPropertyName = "Icon";

        public const string DisplayMessagePropertyName = "DisplayMessage";

        protected readonly IAuthenticationService authenticationService;
        protected readonly IConfigFetcher configFetcher;

        private bool canLoadMore;

        private string icon;

        private bool isBusy;

        private string subTitle = string.Empty;

        private string title = string.Empty;
        private string _displayMessage;

        public UserAccountModel UserAccountModel { get; set; }

        public BaseViewModel(INavigation navigation)
        {
            Navigation = navigation;
            configFetcher = DependencyService.Get<IConfigFetcher>();
            authenticationService = DependencyService.Get<IAuthenticationService>();
            //TODO A CHANGER
            UserAccountModel = authenticationService.GetUserAccount().Result;

        }

        public BaseViewModel() : this(null)
        { 
        } 

        public INavigation Navigation { get; set; }

        public bool IsInitialized { get; set; }

        public string DisplayMessage
        {
            get { return _displayMessage; }
            set { SetProperty(ref _displayMessage, value, DisplayMessagePropertyName); }
        }

        public bool CanLoadMore
        {
            get { return canLoadMore; }
            set { SetProperty(ref canLoadMore, value, CanLoadMorePropertyName); }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value, IsBusyPropertyName); }
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value, TitlePropertyName); }
        }

        public string Subtitle
        {
            get { return subTitle; }
            set { SetProperty(ref subTitle, value, SubtitlePropertyName); }
        }

        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value, IconPropertyName); }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public async Task PushModalAsync(Page page)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(page);
        }

        public async Task PopModalAsync()
        {
            if (Navigation != null)
                await Navigation.PopModalAsync();
        }

        public async Task PushAsync(Page page)
        {
            if (Navigation != null)
                await Navigation.PushAsync(page);
        }

        public async Task PopAsync()
        {
            if (Navigation != null)
                await Navigation.PopAsync();
        }

        protected void SetProperty<U>(
            ref U backingStore, U value,
            string propertyName,
            Action onChanged = null,
            Action<U> onChanging = null)
        {
            if (EqualityComparer<U>.Default.Equals(backingStore, value))
                return;

            if (onChanging != null)
                onChanging(value);

            OnPropertyChanging(propertyName);

            backingStore = value;

            if (onChanged != null)
                onChanged();

            OnPropertyChanged(propertyName);
        }

        #region INotifyPropertyChanging implementation

        public event PropertyChangingEventHandler PropertyChanging;

        #endregion

        public void OnPropertyChanging(string propertyName)
        {
            if (PropertyChanging == null)
                return;

            PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
         
        protected void LogDebug(string message)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(">>>>>> DEBUG : {0} : {1}",message,GetType().FullName));
        }

    }
}
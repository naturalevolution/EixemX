using System.ComponentModel;
using System.Runtime.CompilerServices;
using EixemX.Constants;
using Xamarin.Forms;

namespace EixemX.Controls.Menus
{
    public class HomeMenuItem : INotifyPropertyChanged
    {
        private Color _backgroundColor;
        private string _icon;
        private string _iconUnselected;
        private Color _textColor;

        public HomeMenuItem()
        {
            MenuType = MenuType.Dashboard;
            BackgroundColor = Palette.Transparent;
            TextColor = Palette.GrayMenuText;
        }

        public string Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                OnPropertyChanged("Icon");
            }
        }

        public MenuType MenuType { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public int Id { get; set; }

        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                OnPropertyChanged("BackgroundColor");
            }
        }

        public Color TextColor
        {
            get { return _textColor; }
            set
            {
                _textColor = value;
                OnPropertyChanged("TextColor");
            }
        }

        public string IconUnselected
        {
            get { return _iconUnselected; }
            set
            {
                _iconUnselected = value;
                Icon = _iconUnselected;
            }
        }

        public string IconSelected { get; set; }

        public bool IsSelected { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetSelected(bool isSelected)
        {
            IsSelected = isSelected;
            if (isSelected)
            {
                BackgroundColor = Palette.GrayMenuBackground;
                TextColor = Palette.White;
                Icon = IconSelected;
            }
            else
            {
                BackgroundColor = Palette.Transparent;
                TextColor = Palette.GrayMenuText;
                Icon = IconUnselected;
            }
        }
    }
}
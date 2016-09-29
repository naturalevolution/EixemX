using System.Collections.Generic;
using EixemX.Controls.Menus;
using EixemX.Factories;
using EixemX.Localization;
using EixemX.Pages.Base;
using EixemX.ViewModels.Base;
using Xamarin.Forms;

namespace EixemX.Pages.Menus
{
    public partial class MenuPage : ContentPage
    {
        private List<HomeMenuItem> menuItems;
        private readonly RootPage root;

        public MenuPage(RootPage root)
        {
            this.root = root;
            InitializeComponent();
            BindingContext = new BaseViewModel(Navigation)
            {
                Title = TextResources.Application_Name
            };

            ImageBgMenu.Source = ComponentFactories.Images.NavigationMenuBackground();

            ListViewMenu.ItemsSource = menuItems = GetMenus();

            //ListViewMenu.SelectedItem = menuItems[0];

            ListViewMenu.ItemSelected += ItemSelected;
        }

        private List<HomeMenuItem> GetMenus()
        {
            return new List<HomeMenuItem>
            {
                new HomeMenuItem
                {
                    Title = TextResources.Menu_History,
                    MenuType = MenuType.History,
                    IconUnselected = ImageFactory.MenuHistory,
                    IconSelected = ImageFactory.MenuHistorySelected
                },
                new HomeMenuItem
                {
                    Title = TextResources.Menu_Emprunter,
                    MenuType = MenuType.Emprunter,
                    IconUnselected = ImageFactory.MenuEmprunter,
                    IconSelected = ImageFactory.MenuEmprunterSelected
                },
                new HomeMenuItem
                {
                    Title = TextResources.Menu_Preter,
                    MenuType = MenuType.Preter,
                    IconUnselected = ImageFactory.MenuPreter,
                    IconSelected = ImageFactory.MenuPreterSelected
                },
                new HomeMenuItem
                {
                    Title = TextResources.Menu_Payer,
                    MenuType = MenuType.Payer,
                    IconUnselected = ImageFactory.MenuPayer,
                    IconSelected = ImageFactory.MenuPayerSelected
                },
                new HomeMenuItem
                {
                    Title = TextResources.Menu_Retirer,
                    MenuType = MenuType.Retirer,
                    IconUnselected = ImageFactory.MenuRetirer,
                    IconSelected = ImageFactory.MenuRetirerSelected
                },
                new HomeMenuItem
                {
                    Title = TextResources.Menu_About,
                    MenuType = MenuType.About,
                    IconUnselected = ImageFactory.MenuAbout,
                    IconSelected = ImageFactory.MenuAboutSelected
                },
                new HomeMenuItem
                {
                    Title = TextResources.Menu_Contact,
                    MenuType = MenuType.Contact,
                    IconUnselected = ImageFactory.MenuContact,
                    IconSelected = ImageFactory.MenuContactSelected
                },
                new HomeMenuItem
                {
                    Title = TextResources.Menu_Professional,
                    MenuType = MenuType.Professional,
                    IconUnselected = ImageFactory.MenuProfessional,
                    IconSelected = ImageFactory.MenuProfessionalSelected
                }
            };
        }

        private async void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (ListViewMenu.SelectedItem == null)
                return;

            var menu = (HomeMenuItem) e.SelectedItem;
            menu.SetSelected(true);

            await root.NavigateAsync(menu.MenuType);

            foreach (HomeMenuItem item in ListViewMenu.ItemsSource)
            {
                if ((item.MenuType != menu.MenuType) && item.IsSelected)
                {
                    item.SetSelected(false);
                }
            }
        }
    }
}
using System.Collections.Generic;
using EixemX.Constants;
using EixemX.Controls.Menus;
using EixemX.Factories;
using EixemX.Helpers.Constants;
using EixemX.Localization;
using EixemX.Pages.Base;
using EixemX.ViewModels.Base;
using Xamarin.Forms;

namespace EixemX.Pages.Menus
{
    public partial class MenuPage : ContentPage
    {
        RootPage root;
        List<HomeMenuItem> menuItems;
        public MenuPage(RootPage root)
        {
            this.root = root; 
            InitializeComponent();
            BindingContext = new BaseViewModel(Navigation)
                {
                    Title = "XamarinCRM",
                    Subtitle="XamarinCRM sub",  
            };
             
            ListViewMenu.ItemsSource = menuItems = new List<HomeMenuItem>
                {
                    new HomeMenuItem { Title = TextResources.Menu_History, MenuType = MenuType.History, Icon = ImageFactory.IconHistory },
                    new HomeMenuItem { Title = TextResources.Menu_Emprunter, MenuType = MenuType.Emprunter, Icon = ImageFactory.IconEmprunter  },
                    new HomeMenuItem { Title = TextResources.Menu_Preter, MenuType = MenuType.Preter, Icon = ImageFactory.IconPreter },
                    new HomeMenuItem { Title = TextResources.Menu_Payer, MenuType = MenuType.Payer, Icon = ImageFactory.IconPayer },
                    new HomeMenuItem { Title = TextResources.Menu_Retirer, MenuType = MenuType.Retirer, Icon =ImageFactory.IconRetirer },
                    new HomeMenuItem { Title = TextResources.Menu_About, MenuType = MenuType.About, Icon =ImageFactory.IconAbout},
                    new HomeMenuItem { Title = TextResources.Menu_Contact, MenuType = MenuType.Contact, Icon = ImageFactory.IconContact },
                    new HomeMenuItem { Title = TextResources.Menu_Professional, MenuType = MenuType.Professional, Icon = ImageFactory.IconProfessional }

                };  

            ListViewMenu.SelectedItem = menuItems[0];

            ListViewMenu.ItemSelected += async (sender, e) => 
                {
                    if(ListViewMenu.SelectedItem == null)
                        return;
                    var menu = (HomeMenuItem) e.SelectedItem; 
                    await this.root.NavigateAsync(menu.MenuType); 
                };
        }
    }
}


using System.Collections.Generic;
using System.Threading.Tasks;
using EixemX.Controls.Menus;
using EixemX.Controls.Navigations;
using EixemX.Pages.Home;
using EixemX.ViewModels.Base;
using Xamarin.Forms;

namespace EixemX.Pages.Base
{
    public class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            Pages = new Dictionary<MenuType, NavigationPage>();
            Master = new DashboardPage();
            BindingContext = new BaseViewModel(Navigation)
            {
                Title = "Xamarin CRM",
                Icon = "slideout.png"
            };
            //setup home page
            NavigateAsync(MenuType.Dashboard);
        }

        private Dictionary<MenuType, NavigationPage> Pages { get; }

        private void SetDetailIfNull(Page page)
        {
            if ((Detail == null) && (page != null))
                Detail = page;
        }

        public async Task NavigateAsync(MenuType id)
        {
            Page newPage;
            if (!Pages.ContainsKey(id))
            {
                switch (id)
                {
                    default:
                        var page = new DefaultNavigationPage(new DashboardPage
                        {
                            Title = "Main page From root",
                            Icon = new FileImageSource {File = "sales.png"}
                        });
                        SetDetailIfNull(page);
                        Pages.Add(id, page);
                        break;
                    /* case MenuType.Customers:
                         page = new DefaultNavigationPage(new CustomersPage
                         {
                             BindingContext = new CustomersViewModel() { Navigation = this.Navigation },
                             Title = TextResources.MainTabs_Customers,
                             Icon = new FileImageSource { File = "customers.png" }
                         });
                         SetDetailIfNull(page);
                         Pages.Add(id, page);
                         break;
                     case MenuType.Products:
                         page = new DefaultNavigationPage(new CategoryListPage
                         {
                             BindingContext = new CategoriesViewModel() { Navigation = this.Navigation },
                             Title = TextResources.MainTabs_Products,
                             Icon = new FileImageSource { File = "products.png" }
                         });
                         SetDetailIfNull(page);
                         Pages.Add(id, page);
                         break;
                     case MenuType.About:
                         page = new DefaultNavigationPage(new AboutItemListPage
                         {
                             Title = TextResources.MainTabs_Products,
                             Icon = new FileImageSource { File = "about.png" },
                             BindingContext = new AboutItemListViewModel() { Navigation = this.Navigation }
                         });
                         SetDetailIfNull(page);
                         Pages.Add(id, page);
                         break;
                */

                    //  }
                }

                newPage = Pages[id];
                if (newPage == null)
                    return;

                //pop to root for Windows Phone
                if ((Detail != null) && (Device.OS == TargetPlatform.WinPhone))
                    await Detail.Navigation.PopToRootAsync();

                Detail = newPage;

                if (Device.Idiom != TargetIdiom.Tablet)
                    IsPresented = false;
            }
        }
    }
}
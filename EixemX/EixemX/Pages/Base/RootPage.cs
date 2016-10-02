using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EixemX.Constants;
using EixemX.Controls.Menus;
using EixemX.Factories;
using EixemX.Pages.Borrow;
using EixemX.Pages.Home;
using EixemX.Pages.Menus;
using EixemX.ViewModels.Base;
using Xamarin.Forms;

namespace EixemX.Pages.Base
{
    public class RootPage : MasterDetailPage
    {
        ILabelFactory LabelFactory;
        IButtonFactory ButtonFactory;
        IImageFactory ImageFactory;
        public RootPage()
        {
            Pages = new Dictionary<MenuType, DefaultNavigationPage>();
            Master = new MenuPage(this);

            //setup home page
            NavigateAsync(MenuType.Dashboard);
        } 


        private Dictionary<MenuType, DefaultNavigationPage> Pages { get; }

        private void SetDetailIfNull(Page page)
        {
            if ((Detail == null) && (page != null))
                Detail = page;
        }

        private void AddPageToDictionnary(MenuType id, DefaultNavigationPage page)
        {
            SetDetailIfNull(page);
            Pages.Add(id, page);
        }

        public async Task NavigateAsync(MenuType id)
        { 
            DefaultNavigationPage newPage = null;
            if (!Pages.TryGetValue(id, out newPage)) {
                DefaultNavigationPage page = null;
                switch (id)
                {
                    case MenuType.Dashboard:
                        page = new DefaultNavigationPage(new DashboardPage
                        {
                            Icon = ComponentFactories.Images.GreenLogoFileImage()
                        });
                        AddPageToDictionnary(id, page);
                        break;
                    case MenuType.History:
                        page = new DefaultNavigationPage(new HistoryPage
                        {
                            Icon = ComponentFactories.Images.HistoryPageIcon()
                        });
                        AddPageToDictionnary(id, page);
                        break;
                    case MenuType.Emprunter:
                        page = new DefaultNavigationPage(new BorrowDashboardPage
                        {
                            Icon = ComponentFactories.Images.EmprunterPageIcon()
                        });
                        AddPageToDictionnary(id, page);
                        break;
                    case MenuType.Preter:
                        page = new DefaultNavigationPage(new PreterPage
                        {
                            Icon = ComponentFactories.Images.PreterPageIcon()
                        });
                        AddPageToDictionnary(id, page);
                        break;
                    case MenuType.Payer:
                        page = new DefaultNavigationPage(new PayerPage
                        {
                            Icon = ComponentFactories.Images.PayerPageIcon()
                        });
                        AddPageToDictionnary(id, page);
                        break;
                    case MenuType.Retirer:
                        page = new DefaultNavigationPage(new RetirerPage
                        {
                            Icon = ComponentFactories.Images.RetirerPageIcon()
                        });
                        AddPageToDictionnary(id, page);
                        break;
                    case MenuType.About:
                        page = new DefaultNavigationPage(new AboutPage
                        {
                            Icon = ComponentFactories.Images.AboutPageIcon()
                        });
                        AddPageToDictionnary(id, page);
                        break;
                    case MenuType.Contact:
                        page = new DefaultNavigationPage(new ContactPage
                        {
                            Icon = ComponentFactories.Images.ContactPageIcon()
                        });
                        AddPageToDictionnary(id, page);
                        break;
                    case MenuType.Professional:
                        page = new DefaultNavigationPage(new ProfessionalPage
                        {
                            Icon = ComponentFactories.Images.ProfessionalPageIcon()
                        });
                        AddPageToDictionnary(id, page);
                        break; 
                } 
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
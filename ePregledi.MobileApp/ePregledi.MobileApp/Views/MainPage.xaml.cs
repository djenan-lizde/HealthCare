using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

using ePregledi.MobileApp.Models;

namespace ePregledi.MobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.AboutUs, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.AboutUs:
                        MenuPages.Add(id, new NavigationPage(new AboutUsPage()));
                        break;
                    case (int)MenuItemType.EditUser:
                        MenuPages.Add(id, new NavigationPage(new EditUserPage()));
                        break;
                    case (int)MenuItemType.ReserveExamination:
                        MenuPages.Add(id, new NavigationPage(new ReserveExaminationPage()));
                        break;
                    case (int)MenuItemType.SearchExamination:
                        MenuPages.Add(id, new NavigationPage(new SearchExaminationPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}
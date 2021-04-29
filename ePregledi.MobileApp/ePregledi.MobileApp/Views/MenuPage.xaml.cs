using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using ePregledi.MobileApp.Models;

namespace ePregledi.MobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.AboutUs, Title="O nama" },
                new HomeMenuItem {Id = MenuItemType.EditUser, Title="Uredi profil" },
                new HomeMenuItem {Id = MenuItemType.ReserveExamination, Title="Rezerviraj pregled" },
                new HomeMenuItem {Id = MenuItemType.SearchExamination, Title="Pretrazi preglede" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}
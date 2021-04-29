using ePregledi.MobileApp.ViewModels;
using ePregledi.Models.Responses;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ePregledi.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchExaminationPage : ContentPage
    {
        private readonly SearchExaminationViewModel model = null;
        public SearchExaminationPage()
        {
            InitializeComponent();
            BindingContext = model = new SearchExaminationViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as ExaminationViewModel;
            await Navigation.PushAsync(new ExaminationDetailsPage(item));
        }
    }
}
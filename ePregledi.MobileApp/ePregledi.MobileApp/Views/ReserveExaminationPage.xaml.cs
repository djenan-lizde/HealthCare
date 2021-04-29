using ePregledi.MobileApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ePregledi.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReserveExaminationPage : ContentPage
    {
        private readonly ReserveExaminationViewModel model = null;
        public ReserveExaminationPage()
        {
            InitializeComponent();
            BindingContext = model = new ReserveExaminationViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}
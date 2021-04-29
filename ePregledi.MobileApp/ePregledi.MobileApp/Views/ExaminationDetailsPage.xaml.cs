using ePregledi.MobileApp.ViewModels;
using ePregledi.Models.Responses;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ePregledi.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExaminationDetailsPage : ContentPage
    {
        private readonly ExaminationDetailsViewModel model = null;
        public ExaminationDetailsPage(ExaminationViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = model = new ExaminationDetailsViewModel()
            {
                Examination = viewModel
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}
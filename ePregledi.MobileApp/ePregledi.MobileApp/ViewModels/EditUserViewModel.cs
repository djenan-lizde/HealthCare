using ePregledi.Models.Responses;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ePregledi.MobileApp.ViewModels
{
    public class EditUserViewModel : BaseViewModel
    {
        private readonly APIService _apiServiceUser = new APIService("Users");

        public EditUserViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SaveCommand = new Command(async () => await Save());
        }


        public async Task Init()
        {
            try
            {
                var user = await _apiServiceUser.GetById<UserEditViewModel>(APIService.UserId, "info");

                if (user == null) 
                    return;

                LastName = user.LastName;
                FirstName = user.FirstName;
                PhoneNumber = user.PhoneNumber;
                Username = user.Username;
                Email = user.Email;
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Informacija", "Doslo je do greske", "OK");
                return;
            }
        }

        public async Task Save()
        {
            try
            {
                if (string.IsNullOrEmpty(Username)
                    || string.IsNullOrEmpty(Email)
                    || string.IsNullOrEmpty(FirstName)
                    || string.IsNullOrEmpty(LastName)
                    || string.IsNullOrEmpty(PhoneNumber))
                {
                    await Application.Current.MainPage.DisplayAlert("Greska", "Molimo popunite sva polja", "OK");
                    return;
                }
                var userEdit = new UserEditViewModel
                {
                    Email = Email,
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    Username = Username,
                    UserId = APIService.UserId
                };

                await _apiServiceUser.Update<UserEditViewModel>(userEdit, APIService.UserId.ToString(), "edit");
                await Application.Current.MainPage.DisplayAlert("Informacija", "Podaci uspjesno promijenjeni.", "OK");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Informacija", "Doslo je do greske", "OK");
                return;
            }
        }

        string _lastname = string.Empty;
        public string LastName
        {
            get { return _lastname; }
            set { SetProperty(ref _lastname, value); }
        }

        string _phoneNumber = string.Empty;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }

        string _firstname = string.Empty;
        public string FirstName
        {
            get { return _firstname; }
            set { SetProperty(ref _firstname, value); }
        }

        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        public ICommand InitCommand { get; set; }
        public ICommand SaveCommand { get; set; }
    }
}

using ePregledi.Models.Models;
using ePregledi.Models.Requests;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ePregledi.Models.Enums;
using System.IO;

namespace ePregledi.MobileApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly APIService _apiServiceUsers = new APIService("Users");

        public RegisterViewModel()
        {
            RegisterCommand = new Command(async () => await Register());
        }

        public ICommand RegisterCommand { get; set; }

        async Task Register()
        {
            if (string.IsNullOrEmpty(Username)
                    || string.IsNullOrEmpty(Email)
                    || string.IsNullOrEmpty(Password)
                    || string.IsNullOrEmpty(PasswordConfirmation)
                    || string.IsNullOrEmpty(FirstName)
                    || string.IsNullOrEmpty(LastName)
                    || string.IsNullOrEmpty(PhoneNumber))
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Molimo popunite sva polja", "OK");
                return;
            }

            try
            {
                var user = new UserRegistrationModel
                {
                    Email = Email,
                    FirstName = FirstName,
                    LastName = LastName,
                    Password = Password,
                    PasswordConfirmation = PasswordConfirmation,
                    Username = Username,
                    DateOfBirth = DateOfBirth,
                    PhoneNumber = PhoneNumber,
                    //Photo = ProfilePhoto != null ? ProfilePhoto: new byte[0]
                };

                user.Gender = Gender == "Male" ? Enums.Gender.Male : Enums.Gender.Female;

                await _apiServiceUsers.Insert<User>(user, "registration");
                await Application.Current.MainPage.DisplayAlert("Informacija", "Uspjesno registrovani", "OK");
                Application.Current.MainPage = new LoginPage();
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Informacija", "Doslo je do greske", "OK");
                return;
            }
        }

        Image _profilePhoto = null;
        public Image ProfilePhoto
        {
            get { return _profilePhoto; }
            set
            {
                if (_profilePhoto != value)
                {
                    _profilePhoto = value;
                    OnPropertyChanged("ProfilePhoto");
                }
            }
        }

        string _passwordconfirmation = string.Empty;
        public string PasswordConfirmation
        {
            get { return _passwordconfirmation; }
            set { SetProperty(ref _passwordconfirmation, value); }
        }

        string _gender;
        public string Gender
        {
            get { return _gender; }
            set { SetProperty(ref _gender, value); }
        }

        DateTime _dateOfBirth = DateTime.Now;
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { SetProperty(ref _dateOfBirth, value); }
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

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
    }
}

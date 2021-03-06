using ePregledi.Models.Requests;
using ePregledi.Models.Responses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static ePregledi.Models.Enums.Enums;

namespace ePregledi.MobileApp.ViewModels
{
    public class SearchExaminationViewModel : BaseViewModel
    {
        private readonly APIService _apiServiceExamination = new APIService("Examinations");
        private readonly APIService _apiServiceUsers = new APIService("Users");

        public SearchExaminationViewModel()
        {
            SearchCommand = new Command(async () => await Save());
        }

        public async Task Init()
        {
            try
            {
                if (Doctors.Count == 0)
                {
                    var doctors = await _apiServiceUsers.Get<List<DoctorViewModel>>(null, "doctors");
                    if (doctors.Count > 0)
                        foreach (var item in doctors)
                            Doctors.Add(item);
                    else
                        await Application.Current.MainPage.DisplayAlert("Informacija", "Trenutno nemamo doktora", "OK");
                }

                if (APIService.Role == Role.Doctor.ToString())
                    IsDoctor = true;

                if (APIService.Role == Role.Patient.ToString())
                    IsPatient = true;

            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Informacija", "Greska", "OK");
                return;
            }
        }

        public async Task Save()
        {
            try
            {
                if (APIService.Role == Role.Patient.ToString())
                {
                    if (SelectedDoctor != null && SelectedDoctor.DoctorId != APIService.UserId)
                    {
                        Examinations.Clear();
                        var searchRequest = new SearchExamination
                        {
                            DoctorId = SelectedDoctor.DoctorId,
                            ExaminationDate = ExaminationDate,
                            DeviceType = DeviceType.Mobile,
                            PatientId = APIService.UserId
                        };

                        Search(searchRequest);
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Informacija", "Molimo izaberite doktora ili ste pokusali da izaberete sami sebe za pretragu.", "OK");
                        return;
                    }
                }

                if (APIService.Role == Role.Doctor.ToString())
                {
                    Examinations.Clear();
                    var searchRequest = new SearchExamination
                    {
                        DoctorId = APIService.UserId,
                        ExaminationDate = ExaminationDate,
                        PatientFullName = FullName,
                        DeviceType = DeviceType.Mobile
                    };

                    Search(searchRequest);
                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Informacija", "Doslo je do greske!", "OK");
                return;
            }
        }

        private async void Search(SearchExamination searchRequest)
        {
            var examinations = await _apiServiceExamination.Get<List<ExaminationViewModel>>(searchRequest, "filter");

            if (examinations.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Informacija", "Nema trazenih pregleda", "OK");
                return;
            }

            foreach (var item in examinations)
            {
                Examinations.Add(new ExaminationViewModel
                {
                    Id = item.Id,
                    DoctorName = item.DoctorName,
                    ExaminationDate = item.ExaminationDate,
                    PatientName = item.PatientName
                });
            }
        }

        DoctorViewModel _selectedDoctor = null;
        public DoctorViewModel SelectedDoctor
        {
            get { return _selectedDoctor; }
            set { SetProperty(ref _selectedDoctor, value); }
        }

        DateTime _examinationDate = DateTime.Now;
        public DateTime ExaminationDate
        {
            get { return _examinationDate; }
            set { SetProperty(ref _examinationDate, value); }
        }

        string _fullName = string.Empty;
        public string FullName
        {
            get { return _fullName; }
            set { SetProperty(ref _fullName, value); }
        }

        bool _isDoctor = false;
        public bool IsDoctor
        {
            get { return _isDoctor; }
            set { SetProperty(ref _isDoctor, value); }
        }

        bool _isPatient = false;
        public bool IsPatient
        {
            get { return _isPatient; }
            set { SetProperty(ref _isPatient, value); }
        }

        public ICommand SearchCommand { get; set; }
        public ObservableCollection<DoctorViewModel> Doctors { get; set; } = new ObservableCollection<DoctorViewModel>();
        public ObservableCollection<ExaminationViewModel> Examinations { get; set; } = new ObservableCollection<ExaminationViewModel>();
    }
}

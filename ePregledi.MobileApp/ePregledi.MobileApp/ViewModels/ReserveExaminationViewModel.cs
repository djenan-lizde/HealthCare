using ePregledi.Models.Responses;
using ePregledi.Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ePregledi.Models.Requests;

namespace ePregledi.MobileApp.ViewModels
{
    public class ReserveExaminationViewModel : BaseViewModel
    {
        private readonly APIService _apiServiceUsers = new APIService("Users");
        private readonly APIService _apiServiceExamination = new APIService("Examinations");

        public ReserveExaminationViewModel()
        {
            SaveCommand = new Command(async () => await Init());
        }
        public int UserId { get; set; }

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

                var doctor = await _apiServiceUsers.GetById<DoctorViewModel>(APIService.UserId, "doctor/recommend");

                if (doctor == null)
                    await Application.Current.MainPage.DisplayAlert("Informacija", "Nema prijedloga za doktora", "OK");

                RecommendedDoctor = doctor.FullName;

                if (SelectedDoctor != null)
                {
                    if (ExaminationDate > DateTime.Now.AddDays(2) && APIService.UserId != SelectedDoctor.DoctorId)
                    {
                        bool available = await _apiServiceExamination.Insert<bool>(new ExaminationAvailability
                        {
                            DoctorId = SelectedDoctor.DoctorId,
                            ExaminationDate = ExaminationDate,
                            ExaminationTime = SelectedTime
                        }, "availability");
                        if (available)
                        {
                            var examination = new Examination
                            {
                                Comment = "N/A",
                                DoctorId = SelectedDoctor.DoctorId,
                                ExaminationDate = ExaminationDate,
                                ExaminationTime = SelectedTime,
                                IsFinished = false,
                                PatientId = APIService.UserId,
                                Rating = 0
                            };

                            await _apiServiceExamination.Insert<Examination>(examination, "insert");
                            await Application.Current.MainPage.DisplayAlert("Informacija", "Pregled rezervisan", "OK");
                            return;
                        }
                        await Application.Current.MainPage.DisplayAlert("Informacija", "Termin nije dostupan", "OK");
                        return;
                    }
                    await Application.Current.MainPage.DisplayAlert("Informacija", "Pregled treba biti zakazan najmanje 3 dana ranije " +
                        "ili se pokusali zakazati termin kod samih sebe", "OK");
                    return;
                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Informacija", "Doslo je do greske.", "OK");
                return;
            }
        }

        DoctorViewModel _selectedDoctor = null;
        public DoctorViewModel SelectedDoctor
        {
            get { return _selectedDoctor; }
            set { SetProperty(ref _selectedDoctor, value); }
        }

        string _recommendedDoctor = null;
        public string RecommendedDoctor
        {
            get { return _recommendedDoctor; }
            set { SetProperty(ref _recommendedDoctor, value); }
        }

        DateTime _examinationDate = DateTime.Now;
        public DateTime ExaminationDate
        {
            get { return _examinationDate; }
            set { SetProperty(ref _examinationDate, value); }
        }

        TimeSpan _selectedTime = TimeSpan.Zero;
        public TimeSpan SelectedTime
        {
            get { return _selectedTime; }
            set { SetProperty(ref _selectedTime, value); }
        }


        public ICommand SaveCommand { get; set; }
        public ObservableCollection<DoctorViewModel> Doctors { get; set; } = new ObservableCollection<DoctorViewModel>();
    }
}

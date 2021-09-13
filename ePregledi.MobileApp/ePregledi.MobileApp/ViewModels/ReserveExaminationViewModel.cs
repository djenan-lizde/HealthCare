using ePregledi.Models.Responses;
using ePregledi.Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ePregledi.Models.Requests;
using System.Linq;

namespace ePregledi.MobileApp.ViewModels
{
    public class ReserveExaminationViewModel : BaseViewModel
    {
        private readonly APIService _apiServiceUsers = new APIService("Users");
        private readonly APIService _apiServiceExamination = new APIService("Examinations");

        public ReserveExaminationViewModel()
        {
            SaveCommand = new Command(async () => await Save());
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
                        foreach (var item in doctors.ToList())
                            Doctors.Add(item);
                    else
                        await Application.Current.MainPage.DisplayAlert("Informacija", "Trenutno nemamo doktora", "OK");
                }

                if (Ambulances.Count == 0)
                {
                    var ambulances = await _apiServiceExamination.Get<List<Ambulance>>(null, "ambulance");
                    if (ambulances.Count > 0)
                        foreach (var item in ambulances.ToList())
                            Ambulances.Add(item);
                    else
                        await Application.Current.MainPage.DisplayAlert("Informacija", "Trenutno nemamo ambulanti", "OK");
                }

                if (Departments.Count == 0)
                {
                    var departments = await _apiServiceExamination.Get<List<Department>>(null, "department");
                    if (departments.Count > 0)
                        foreach (var item in departments.ToList())
                            Departments.Add(item);
                    else
                        await Application.Current.MainPage.DisplayAlert("Informacija", "Trenutno nemamo odjela", "OK");
                }

                if (Rooms.Count == 0)
                {
                    var rooms = await _apiServiceExamination.Get<List<Room>>(null, "rooms");
                    if (rooms.Count > 0)
                        foreach (var item in rooms.ToList())
                            Rooms.Add(item);
                    else
                        await Application.Current.MainPage.DisplayAlert("Informacija", "Trenutno nemamo soba", "OK");
                }

                var doctor = await _apiServiceUsers.GetById<DoctorViewModel>(APIService.UserId, "doctor/recommend");

                if (doctor == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Informacija", "Nema prijedloga za doktora", "OK");
                    return;
                }

                RecommendedDoctor = doctor.FullName;


            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Informacija", "Doslo je do greske.", "OK");
                return;
            }
        }

        public async Task Save()
        {
            try
            {
                if (SelectedDoctor != null && SelectedAmbulance != null && SelectedDepartment != null && SelectedRoom != null)
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
                                Rating = 0,
                                AmbulanceId = SelectedAmbulance.Id,
                                DepartmentId = SelectedDepartment.Id,
                                RoomId = SelectedRoom.Id
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
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Informacija", "Odaberite vrijednosti u padajucoj listi", "OK");
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

        Ambulance _selectedAmbulance = null;
        public Ambulance SelectedAmbulance
        {
            get { return _selectedAmbulance; }
            set { SetProperty(ref _selectedAmbulance, value); }
        }

        Department _selectedDepartment = null;
        public Department SelectedDepartment
        {
            get { return _selectedDepartment; }
            set { SetProperty(ref _selectedDepartment, value); }
        }

        Room _selectedRoom = null;
        public Room SelectedRoom
        {
            get { return _selectedRoom; }
            set { SetProperty(ref _selectedRoom, value); }
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
        public ObservableCollection<Ambulance> Ambulances { get; set; } = new ObservableCollection<Ambulance>();
        public ObservableCollection<Department> Departments { get; set; } = new ObservableCollection<Department>();
        public ObservableCollection<Room> Rooms { get; set; } = new ObservableCollection<Room>();
    }
}

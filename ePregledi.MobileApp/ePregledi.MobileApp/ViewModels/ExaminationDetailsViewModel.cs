using ePregledi.Models.Models;
using ePregledi.Models.Responses;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ePregledi.MobileApp.ViewModels
{
    public class ExaminationDetailsViewModel : BaseViewModel
    {
        private readonly APIService _apiServiceExamination = new APIService("Examinations");

        public ExaminationDetailsViewModel()
        {
            InitCommand = new Command(async () => await Init());
            RateDoctor = new Command(async () => await Rate());
        }

        public ExaminationViewModel Examination { get; set; }
        public ExaminationDetails ExaminationDetails { get; set; }

        public async Task Init()
        {
            try
            {
                var eD = await _apiServiceExamination.GetById<ExaminationDetails>(Examination.Id, "details");

                if (eD == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Informacija", "Nema detalja za pregled", "OK");
                    return;
                }

                ExaminationDetails = eD;
                ExaminationDate = eD.ReservationDate;
                DiagnosisName = eD.Diagnosis.DiagnosisName;
                Description = eD.Diagnosis.Description;

                var medicine = await _apiServiceExamination.GetById<Medicine>(eD.Recipe.MedicineId, "medicine");
                if (medicine == null)
                {
                    Medicine = "N/A";
                }
                else
                {
                    Medicine = medicine.Name;
                }
                Instruction = eD.Recipe.Instruction;
                Info = eD.Referral.Info;
                IsFinished = eD.Diagnosis.Examination.IsFinished;
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Informacija", "Nema detalja za pregled", "OK");
                return;
            }
        }

        public async Task Rate()
        {
            try
            {
                var ex = await _apiServiceExamination.GetById<Examination>(ExaminationDetails.ExaminationId);

                if (ex == null)
                    return;

                ex.IsFinished = true;
                ex.Comment = Comment;
                if (Rating < 1 || Rating > 5)
                {
                    await Application.Current.MainPage.DisplayAlert("Informacija", "Ocjena moze biti samo veca od 0 i manja od 6", "OK");
                    return;
                }
                ex.Rating = Rating;

                var newEx = new Examination();
                newEx = ex;
                await _apiServiceExamination.Update<Examination>(newEx, newEx.Id.ToString(), "rate");
                await Application.Current.MainPage.DisplayAlert("Informacija", "Doktor uspjesno ocijenjen.", "OK");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Informacija", "Greska", "OK");
                return;
            }
        }


        DateTime _examinationDate = DateTime.Now;
        public DateTime ExaminationDate
        {
            get { return _examinationDate; }
            set { SetProperty(ref _examinationDate, value); }
        }

        string _diagnosisName = string.Empty;
        public string DiagnosisName
        {
            get { return _diagnosisName; }
            set { SetProperty(ref _diagnosisName, value); }
        }

        string _description = string.Empty;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        string _medicine = string.Empty;
        public string Medicine
        {
            get { return _medicine; }
            set { SetProperty(ref _medicine, value); }
        }

        string _instruction = string.Empty;
        public string Instruction
        {
            get { return _instruction; }
            set { SetProperty(ref _instruction, value); }
        }

        string _info = string.Empty;
        public string Info
        {
            get { return _info; }
            set { SetProperty(ref _info, value); }
        }

        bool _isFinished = false;
        public bool IsFinished
        {
            get { return _isFinished; }
            set { SetProperty(ref _isFinished, value); }
        }

        string _doctorName = string.Empty;
        public string DoctorName
        {
            get { return _doctorName; }
            set { SetProperty(ref _doctorName, value); }
        }

        string _comment = string.Empty;
        public string Comment
        {
            get { return _comment; }
            set { SetProperty(ref _comment, value); }
        }

        int _rating = 0;
        public int Rating
        {
            get { return _rating; }
            set { SetProperty(ref _rating, value); }
        }

        public ICommand InitCommand { get; set; }
        public ICommand RateDoctor { get; set; }
    }
}

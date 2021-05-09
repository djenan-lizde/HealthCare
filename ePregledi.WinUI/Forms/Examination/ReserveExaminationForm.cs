using ePregledi.Models.Requests;
using ePregledi.Models.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ePregledi.WinUI.Forms.Examination
{
    public partial class ReserveExaminationForm : Form
    {
        private readonly APIService _apiServiceUsers = new APIService("Users");
        private readonly APIService _apiServiceExamination = new APIService("Examinations");

        public ReserveExaminationForm()
        {
            InitializeComponent();
            TimePicker.Format = DateTimePickerFormat.Time;
            TimePicker.ShowUpDown = true;
            AutoValidate = AutoValidate.Disable;
        }

        private async void ReserveExaminationForm_Load(object sender, EventArgs e)
        {
            var result = await _apiServiceUsers.Get<List<DoctorViewModel>>(null, "doctors");

            result.Insert(0, new DoctorViewModel());
            CmbDoctors.DataSource = result;
            CmbDoctors.ValueMember = "DoctorId";
            CmbDoctors.DisplayMember = "FullName";

            var doctor = await _apiServiceUsers.GetById<DoctorViewModel>(APIService.UserId, "doctor/recommend");

            if (doctor == null)
                txtRecomDoctor.Text = "No recommendation";

            txtRecomDoctor.Text = doctor.FullName;
        }

        private async void BtnReserve_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    if (DatePicker.Value > DateTime.Now.AddDays(2) && APIService.UserId != int.Parse(CmbDoctors.SelectedValue.ToString()))
                    {
                        bool available = await _apiServiceExamination.Insert<bool>(new ExaminationAvailability
                        {
                            DoctorId = int.Parse(CmbDoctors.SelectedValue.ToString()),
                            ExaminationDate = DatePicker.Value,
                            ExaminationTime = TimePicker.Value.TimeOfDay
                        }, "availability");
                        if (available)
                        {
                            var model = new Models.Models.Examination
                            {
                                Comment = "N/A",
                                DoctorId = int.Parse(CmbDoctors.SelectedValue.ToString()),
                                ExaminationDate = DatePicker.Value,
                                ExaminationTime = TimePicker.Value.TimeOfDay,
                                IsFinished = false,
                                PatientId = APIService.UserId,
                                Rating = 0
                            };
                            await _apiServiceExamination.Insert<Models.Models.Examination>(model, "insert");
                            MessageBox.Show("Pregled rezervisan", "Informacija", MessageBoxButtons.OK);
                            Close();
                            return;
                        }
                        MessageBox.Show("Termin nije dostupan", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    MessageBox.Show("Pregled treba biti zakazan najmanje 3 dana ranije " +
                        "ili ste pokusali zakazati termin kod samih sebe", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                catch (Exception)
                {
                    MessageBox.Show("Doslo je do greske", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Molimo popunite sva polja", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void CmbDoctors_Validating(object sender, CancelEventArgs e)
        {
            if (CmbDoctors.SelectedIndex == 0 || CmbDoctors.SelectedIndex == -1)
            {
                errorProvider1.SetError(CmbDoctors, "You need to select option from combo box");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(CmbDoctors, null);
            }
        }
    }
}

using ePregledi.Models.Requests;
using ePregledi.Models.Responses;
using ePregledi.WinUI.Forms.Examination;
using ePregledi.WinUI.Forms.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ePregledi.Models.Enums.Enums;

namespace ePregledi.WinUI
{
    public partial class HomePageForm : Form
    {
        private readonly APIService _apiServiceExamination = new APIService("Examinations");
        private readonly APIService _apiServiceUsers = new APIService("Users");

        private readonly DeviceType DeviceType = DeviceType.Desktop; 

        public HomePageForm()
        {
            InitializeComponent();
        }

        private async void HomePageForm_Load(object sender, EventArgs e)
        {
            LblUsername.Text = $"Hello, {APIService.UserName}";
            CmbDoctors.Visible = false;
            LblDoctor.Visible = false;

            var searchRequest = new SearchExamination
            {
                ExaminationDate = DateTime.Now.Date,
                DeviceType = DeviceType
            };

            if (APIService.Role == Role.Doctor.ToString())
                searchRequest.DoctorId = APIService.UserId;

            if (APIService.Role == Role.Patient.ToString())
            {
                searchRequest.PatientId = APIService.UserId;
                CmbDoctors.Visible = true;
                LblDoctor.Visible = true;
                ChBoxPatient.Visible = false;
                var doctors = await _apiServiceUsers.Get<List<DoctorViewModel>>(null, "doctors");

                doctors.Insert(0, new DoctorViewModel());
                CmbDoctors.DataSource = doctors;
                CmbDoctors.ValueMember = "DoctorId";
                CmbDoctors.DisplayMember = "FullName";
            }

            var result = await _apiServiceExamination.Get<List<ExaminationViewModel>>(searchRequest, "filter");

            if (result.Count == 0)
            {
                MessageBox.Show("Nema zakazanih pregleda za odabrani datum.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DgvExamination.DataSource = result;
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void LblReserve_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ReserveExaminationForm frm = new ReserveExaminationForm();
            frm.Show();
        }

        private void DgvExamination_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var examinationId = DgvExamination.SelectedRows[0].Cells[0].Value;
            var doctorId = DgvExamination.SelectedRows[0].Cells[1].Value;
            var patientId = DgvExamination.SelectedRows[0].Cells[2].Value;

            ExaminationDetailsForm frm = new ExaminationDetailsForm((int)examinationId, (int)doctorId, (int)patientId);
            frm.Show();
        }

        private void LblEditProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditForm frm = new EditForm();
            frm.Show();
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            Search();
        }

        private async void Search()
        {
            DgvExamination.DataSource = null;

            var searchRequest = new SearchExamination
            {
                ExaminationDate = DateReservation.Value.Date,
                DeviceType = DeviceType
            };

            if (APIService.Role == Role.Doctor.ToString())
                searchRequest.DoctorId = APIService.UserId;

            if (APIService.Role == Role.Patient.ToString())
            {
                searchRequest.DoctorId = int.Parse(CmbDoctors.SelectedValue.ToString());
                searchRequest.PatientId = APIService.UserId;
            }

            if (ChBoxPatient.Checked)
            {
                searchRequest.DoctorId = int.Parse(CmbDoctors.SelectedValue.ToString());
                searchRequest.PatientId = APIService.UserId;
            }

            var result = await _apiServiceExamination.Get<List<ExaminationViewModel>>(searchRequest, "filter");

            if (result.Count == 0)
            {
                MessageBox.Show("Nema zakazanih pregleda za odabrani datum.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DgvExamination.DataSource = result;
        }

        private async void ChBoxPatient_CheckedChanged(object sender, EventArgs e)
        {
            DgvExamination.DataSource = null;
            if (ChBoxPatient.Checked)
            {
                CmbDoctors.Visible = true;
                LblDoctor.Visible = true;
                var doctors = await _apiServiceUsers.Get<List<DoctorViewModel>>(null, "doctors");

                doctors.Insert(0, new DoctorViewModel());
                CmbDoctors.DataSource = doctors;
                CmbDoctors.ValueMember = "DoctorId";
                CmbDoctors.DisplayMember = "FullName";

                APIService.Role = Role.Patient.ToString();

                MessageBox.Show("Sada ste u ulozi pacijenta.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ChBoxPatient.Checked = false;
            CmbDoctors.Visible = false;
            LblDoctor.Visible = false;
            APIService.Role = Role.Doctor.ToString();
            MessageBox.Show("Sada ste u ulozi doktora.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

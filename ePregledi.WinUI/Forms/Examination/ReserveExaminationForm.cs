using ePregledi.Models.Models;
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

            var ambulances = await _apiServiceExamination.Get<List<Ambulance>>(null, "ambulance");

            ambulances.Insert(0, new Ambulance());
            CmbAmbulance.DataSource = ambulances;
            CmbAmbulance.ValueMember = "Id";
            CmbAmbulance.DisplayMember = "Name";

            var doctor = await _apiServiceUsers.GetById<DoctorViewModel>(APIService.UserId, "doctor/recommend");

            if (doctor == null)
            {
                txtRecomDoctor.Text = "No recommendation";
                return;
            }

            txtRecomDoctor.Text = doctor.FullName;
            CmbDepartment.Enabled = false;
            CmbRooms.Enabled = false;
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
                                Rating = 0,
                                RoomId = int.Parse(CmbRooms.SelectedValue.ToString()),
                                AmbulanceId = int.Parse(CmbAmbulance.SelectedValue.ToString()),
                                DepartmentId = int.Parse(CmbDepartment.SelectedValue.ToString())
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

        private async void CmbAmbulance_SelectedIndexChanged(object sender, EventArgs e)
        {
            var departments = await _apiServiceExamination.Get<List<Department>>(null, "department");
            CmbDepartment.Enabled = true;
            departments.Insert(0, new Department());
            CmbDepartment.DataSource = departments;
            CmbDepartment.ValueMember = "Id";
            CmbDepartment.DisplayMember = "Name";
        }

        private async void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rooms = await _apiServiceExamination.Get<List<Room>>(null, "rooms");
            CmbRooms.Enabled = true;
            rooms.Insert(0, new Room());
            CmbRooms.DataSource = rooms;
            CmbRooms.ValueMember = "Id";
            CmbRooms.DisplayMember = "Name";
        }

        private void CmbDepartment_Validating(object sender, CancelEventArgs e)
        {
            if (CmbDepartment.SelectedIndex == 0 || CmbDepartment.SelectedIndex == -1)
            {
                errorProvider1.SetError(CmbDepartment, "You need to select option from combo box");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(CmbDepartment, null);
            }
        }

        private void CmbAmbulance_Validating(object sender, CancelEventArgs e)
        {
            if (CmbAmbulance.SelectedIndex == 0 || CmbAmbulance.SelectedIndex == -1)
            {
                errorProvider1.SetError(CmbAmbulance, "You need to select option from combo box");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(CmbAmbulance, null);
            }
        }

        private void CmbRooms_Validating(object sender, CancelEventArgs e)
        {
            if (CmbRooms.SelectedIndex == 0 || CmbRooms.SelectedIndex == -1)
            {
                errorProvider1.SetError(CmbRooms, "You need to select option from combo box");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(CmbRooms, null);
            }
        }
    }
}

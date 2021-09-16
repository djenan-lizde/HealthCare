using ePregledi.Models.Responses;
using System;
using System.Windows.Forms;

namespace ePregledi.WinUI.Forms.Examination
{
    public partial class RateDoctorForm : Form
    {
        private readonly APIService _apiServiceUser = new APIService("Users");
        private readonly APIService _apiServiceExamination = new APIService("Examinations");

        private int ExaminationId { get; set; }
        private int DoctorId { get; set; }

        public RateDoctorForm(int examinationId, int doctorId)
        {
            InitializeComponent();
            ExaminationId = examinationId;
            DoctorId = doctorId;
            AutoValidate = AutoValidate.Disable;
        }

        private async void RateDoctorForm_Load(object sender, EventArgs e)
        {
            var doctor = await _apiServiceUser.GetById<DoctorViewModel>(DoctorId, "doctor");

            if (doctor == null)
                return;

            LblDoctor.Text = $"Doctor: {doctor.FullName}";

            if (doctor.DoctorId == APIService.UserId)
            {
                MessageBox.Show("Ne mozete sami sebe ocjeniti.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    var ex = await _apiServiceExamination.GetById<Models.Models.Examination>(ExaminationId);

                    if (ex == null)
                        return;

                    ex.IsFinished = true;
                    ex.Comment = TxtComment.Text;   
                    ex.Rating = (int)RateNumberPicker.Value;

                    var newEx = new Models.Models.Examination();
                    newEx = ex;

                    await _apiServiceExamination.Update<Models.Models.Examination>(newEx, newEx.Id.ToString(), "rate");
                    MessageBox.Show("Uspjesno sacuvano", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
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

        private void RateNumberPicker_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (RateNumberPicker.Value < 1 || RateNumberPicker.Value > 5)
            {
                errorProvider1.SetError(RateNumberPicker, "Value can't be lower than 1 or higher than 5.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(RateNumberPicker, null);
            }
        }
        private void TxtComment_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtComment.Text))
            {
                errorProvider1.SetError(TxtComment, "Input can not be an empty string.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TxtComment, null);
            }
        }
    }
}

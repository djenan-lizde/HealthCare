using ePregledi.Models.Models;
using System;
using System.Windows.Forms;

namespace ePregledi.WinUI.Forms.Examination
{
    public partial class FrmMedicine : Form
    {
        private readonly APIService _apiServiceExamination = new APIService("Examinations");
        public FrmMedicine()
        {
            InitializeComponent();
            AutoValidate = AutoValidate.Disable;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    var medicine = new Medicine()
                    {
                        Name = TxtMedicineName.Text
                    };

                    await _apiServiceExamination.Insert<Medicine>(medicine, "medicine");

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

        private void TxtMedicineName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtMedicineName.Text))
            {
                errorProvider1.SetError(TxtMedicineName, "Input can not be an empty string.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TxtMedicineName, null);
            }
        }

        private void FrmMedicine_Load(object sender, EventArgs e)
        {
            if (APIService.Role.Equals("Patient"))
            {
                MessageBox.Show("Pacijent ne moze dodati lijek.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}

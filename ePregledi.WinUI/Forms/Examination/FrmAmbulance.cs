using ePregledi.Models.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ePregledi.WinUI.Forms.Examination
{
    public partial class FrmAmbulance : Form
    {
        private readonly APIService _apiServiceExamination = new APIService("Examinations");
        public FrmAmbulance()
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
                    var ambulance = new Ambulance()
                    {
                        Name = TxtAmbulanceName.Text
                    };

                    await _apiServiceExamination.Insert<Ambulance>(ambulance, "ambulance");

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

        private void TxtAmbulanceName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtAmbulanceName.Text))
            {
                errorProvider1.SetError(TxtAmbulanceName, "Input can't be an empty string or can't contains numbers.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TxtAmbulanceName, null);
            }
        }
    }
}

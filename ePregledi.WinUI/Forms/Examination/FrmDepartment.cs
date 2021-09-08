using ePregledi.Models.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ePregledi.WinUI.Forms.Examination
{
    public partial class FrmDepartment : Form
    {
        private readonly APIService _apiServiceExamination = new APIService("Examinations");
        public FrmDepartment()
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
                    var department = new Department()
                    {
                        Name = TxtDepartmentName.Text,
                        Abbreviation = TxtAbbrv.Text
                    };

                    await _apiServiceExamination.Insert<Department>(department, "department");

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

        private void TxtDepartmentName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtDepartmentName.Text))
            {
                errorProvider1.SetError(TxtDepartmentName, "Input can't be an empty string or can't contains numbers.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TxtDepartmentName, null);
            }
        }

        private void TxtAbbrv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtAbbrv.Text))
            {
                errorProvider1.SetError(TxtAbbrv, "Input can't be an empty string or can't contains numbers.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TxtAbbrv, null);
            }
        }
    }
}

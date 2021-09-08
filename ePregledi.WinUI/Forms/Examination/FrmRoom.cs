using ePregledi.Models.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ePregledi.WinUI.Forms.Examination
{
    public partial class FrmRoom : Form
    {
        private readonly APIService _apiServiceExamination = new APIService("Examinations");
        public FrmRoom()
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
                    var room = new Room()
                    {
                        Name = TxtRoomName.Text,
                        Number = (int)RoomNumberPicker.Value
                    };

                    await _apiServiceExamination.Insert<Room>(room, "rooms");

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
            if (string.IsNullOrWhiteSpace(TxtRoomName.Text))
            {
                errorProvider1.SetError(TxtRoomName, "Input can't be an empty string or can't contains numbers.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TxtRoomName, null);
            }
        }

        private void RoomNumberPicker_Validating(object sender, CancelEventArgs e)
        {
            if (RoomNumberPicker.Value < 1)
            {
                errorProvider1.SetError(RoomNumberPicker, "Value can't be lower than 1");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(RoomNumberPicker, null);
            }
        }
    }
}

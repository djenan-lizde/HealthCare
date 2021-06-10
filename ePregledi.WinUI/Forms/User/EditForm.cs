using ePregledi.Models.Responses;
using ePregledi.WinUI.Helper;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ePregledi.WinUI.Forms.User
{
    public partial class EditForm : Form
    {
        private readonly APIService _apiServiceUsers = new APIService("Users");

        UserEditViewModel userEdit = new UserEditViewModel();

        public EditForm()
        {
            InitializeComponent();
            AutoValidate = AutoValidate.Disable;
        }

        private async void EditForm_Load(object sender, EventArgs e)
        {
            var user = await _apiServiceUsers.GetById<UserEditViewModel>(APIService.UserId, "info");

            if (user == null)
                return;

            TxtFirstName.Text = user.FirstName;
            TxtLastName.Text = user.LastName;
            TxtEmail.Text = user.Email;
            TxtPhoneNumber.Text = user.PhoneNumber;
            TxtUserName.Text = user.Username;
            if (user.Photo.Length != 0)
            {
                Image image = ImageResizer.ByteArrayToImage(user.Photo);
                var newImage = ImageResizer.ResizeImage(image, 200, 200);
                PicBoxProfile.Image = newImage;
                userEdit.Photo = user.Photo;
            }
        }

        private async void BtnsSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    userEdit.FirstName = TxtFirstName.Text;
                    userEdit.LastName = TxtLastName.Text;
                    userEdit.PhoneNumber = TxtPhoneNumber.Text;
                    userEdit.Username = TxtUserName.Text;
                    userEdit.Email = TxtEmail.Text;
                    userEdit.UserId = APIService.UserId;

                    await _apiServiceUsers.Update<UserEditViewModel>(userEdit, APIService.UserId.ToString(), "edit");
                    MessageBox.Show("Uspjesno sacuvano.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Doslo je do greske", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Molimo popunite sva polja", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void BtnAddLogo_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;

                var file = File.ReadAllBytes(fileName);

                userEdit.Photo = file;

                Image image = Image.FromFile(fileName);
                Image newImage = ImageResizer.ResizeImage(image, 200, 200);
                PicBoxProfile.Image = newImage;
            }
        }
        private void TxtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtFirstName.Text) || Regex.Match(TxtFirstName.Text, @".*([\d]+).*").Success)
            {
                errorProvider1.SetError(TxtFirstName, "Input can't be an empty string or can't contains numbers.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TxtFirstName, null);
            }
        }
        private void TxtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtLastName.Text) || Regex.Match(TxtLastName.Text, @".*([\d]+).*").Success)
            {
                errorProvider1.SetError(TxtLastName, "Input can't be an empty string or can't contains numbers.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TxtLastName, null);
            }
        }
        private void TxtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtUserName.Text))
            {
                errorProvider1.SetError(TxtUserName, "Invalid mail format.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TxtUserName, null);
            }
        }
        private void TxtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtEmail.Text) || !TxtEmail.Text.Contains("@"))
            {
                errorProvider1.SetError(TxtEmail, "Invalid mail format.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TxtEmail, null);
            }
        }
        private void TxtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtPhoneNumber.Text) || TxtPhoneNumber.Text[0] != '+' ||
                Regex.Match(TxtFirstName.Text, @"^(\+0?1\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$").Success)
            {
                errorProvider1.SetError(TxtPhoneNumber, "Phone needs to start with +.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TxtPhoneNumber, null);
            }
        }
    }
}

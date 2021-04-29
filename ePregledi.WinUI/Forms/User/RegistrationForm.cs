using ePregledi.Models.Extensions;
using ePregledi.Models.Requests;
using ePregledi.Models.Responses;
using ePregledi.WinUI.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static ePregledi.Models.Enums.Enums;

namespace ePregledi.WinUI
{
    public partial class RegistrationForm : Form
    {
        private readonly APIService _apiServiceUsers = new APIService("Users");

        UserRegistrationModel userRegistrationModel = new UserRegistrationModel();

        public RegistrationForm()
        {
            InitializeComponent();
            AutoValidate = AutoValidate.Disable;
        }

        private void RegistrationForm_Load(object sender, System.EventArgs e)
        {
            var genders = Globals.ToPairList<Gender>(typeof(Gender)).ToList();
            genders.Insert(0, new KeyValuePair<int, string>());
            CmbGender.DataSource = genders.ToList();
            CmbGender.DisplayMember = "Value";
            CmbGender.ValueMember = "Key";
        }
        private void BtnAddLogo_Click(object sender, System.EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;

                var file = File.ReadAllBytes(fileName);

                userRegistrationModel.Photo = file;

                Image image = Image.FromFile(fileName);
                Image newImage = ImageResizer.ResizeImage(image, 200, 200);
                PicBoxProfile.Image = newImage;
            }
        }
        private async void BtnRegister_Click(object sender, System.EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    if (TxtPassword.Text != TxtPassConf.Text)
                    {
                        TxtPassword.Text = TxtPassConf.Text = "";
                        MessageBox.Show("Passwordi i potvrda passworda nije ista. Pokusajte ponovo", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (PicBoxProfile.Image == null)
                    {
                        MessageBox.Show("Molimo unesite profilnu sliku.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    userRegistrationModel.FirstName = TxtFirstName.Text;
                    userRegistrationModel.LastName = TxtLastName.Text;
                    userRegistrationModel.Password = TxtPassword.Text;
                    userRegistrationModel.PasswordConfirmation = TxtPassConf.Text;
                    userRegistrationModel.PhoneNumber = TxtPhoneNumber.Text;
                    userRegistrationModel.Username = TxtUserName.Text;
                    userRegistrationModel.Email = TxtEmail.Text;
                    userRegistrationModel.Gender = (Gender)CmbGender.SelectedIndex;

                    await _apiServiceUsers.Insert<UserRegistrationResult>(userRegistrationModel, "registration");

                    MessageBox.Show("Uspjesno registrovani.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoginForm frm = new LoginForm();
                    frm.Show();
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Doslo je do greske", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void TxtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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
        private void TxtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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
        private void TxtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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
        private void TxtPhoneNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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
        private void CmbGender_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CmbGender.SelectedIndex == 0 || CmbGender.SelectedIndex == -1)
            {
                errorProvider1.SetError(CmbGender, "You need to select option from combo box");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(CmbGender, null);
            }
        }
        private void TxtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtPassword.Text))
            {
                errorProvider1.SetError(TxtPassword, "Input can not be an empty string.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TxtPassword, null);
            }
        }
        private void TxtUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtUserName.Text))
            {
                errorProvider1.SetError(TxtUserName, "Input can not be an empty string.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TxtUserName, null);
            }
        }
    }
}

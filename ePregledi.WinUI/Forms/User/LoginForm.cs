using ePregledi.Models.Responses;
using System;
using System.Windows.Forms;

namespace ePregledi.WinUI
{
    public partial class LoginForm : Form
    {
        private readonly APIService _apiServiceUsers = new APIService("Users");
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void BtnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtUsername.Text) || string.IsNullOrWhiteSpace(TxtPassword.Text))
                {
                    MessageBox.Show("Insert valid data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtUsername.Text = TxtPassword.Text = "";
                    return;
                }

                var data = await _apiServiceUsers.Insert<UserAuthenticationResult>(new
                {
                    username = TxtUsername.Text,
                    password = TxtPassword.Text
                }, "login");

                if (data == null)
                {
                    MessageBox.Show("Wrong username or password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtUsername.Text = TxtPassword.Text = "";
                    return;
                }

                APIService.Token = data.Token;
                APIService.UserId = data.Id;
                APIService.UserName = data.Username;
                APIService.Role = data.Role;
                HomePageForm frm = new HomePageForm();
                frm.Show();
                frm.FormClosing += LoginForm_FormClosing;
                Hide();
            }
            catch (Exception)
            {
                TxtUsername.Text = TxtPassword.Text = "";
                MessageBox.Show("Wrong username or password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Show();
            TxtUsername.Text = TxtPassword.Text = "";
        }

        private void LnkRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm frm = new RegistrationForm();
            frm.Show();
        }
    }
}

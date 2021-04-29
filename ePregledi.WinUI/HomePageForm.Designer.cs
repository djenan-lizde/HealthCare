
namespace ePregledi.WinUI
{
    partial class HomePageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblDoctor = new System.Windows.Forms.Label();
            this.DateReservation = new System.Windows.Forms.DateTimePicker();
            this.CmbDoctors = new System.Windows.Forms.ComboBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.LblReserve = new System.Windows.Forms.LinkLabel();
            this.DgvExamination = new System.Windows.Forms.DataGridView();
            this.LblEditProfile = new System.Windows.Forms.LinkLabel();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.ChBoxPatient = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvExamination)).BeginInit();
            this.SuspendLayout();
            // 
            // LblUsername
            // 
            this.LblUsername.AutoSize = true;
            this.LblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsername.Location = new System.Drawing.Point(730, 32);
            this.LblUsername.Name = "LblUsername";
            this.LblUsername.Size = new System.Drawing.Size(124, 29);
            this.LblUsername.TabIndex = 0;
            this.LblUsername.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Datum rezervacije";
            // 
            // LblDoctor
            // 
            this.LblDoctor.AutoSize = true;
            this.LblDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDoctor.Location = new System.Drawing.Point(335, 57);
            this.LblDoctor.Name = "LblDoctor";
            this.LblDoctor.Size = new System.Drawing.Size(57, 20);
            this.LblDoctor.TabIndex = 2;
            this.LblDoctor.Text = "Doktor";
            // 
            // DateReservation
            // 
            this.DateReservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateReservation.Location = new System.Drawing.Point(27, 91);
            this.DateReservation.Name = "DateReservation";
            this.DateReservation.Size = new System.Drawing.Size(237, 24);
            this.DateReservation.TabIndex = 3;
            // 
            // CmbDoctors
            // 
            this.CmbDoctors.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDoctors.FormattingEnabled = true;
            this.CmbDoctors.Location = new System.Drawing.Point(339, 91);
            this.CmbDoctors.Name = "CmbDoctors";
            this.CmbDoctors.Size = new System.Drawing.Size(231, 26);
            this.CmbDoctors.TabIndex = 4;
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BtnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.ForeColor = System.Drawing.Color.Black;
            this.BtnSearch.Location = new System.Drawing.Point(735, 451);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(149, 43);
            this.BtnSearch.TabIndex = 6;
            this.BtnSearch.Text = "Pretrazi";
            this.BtnSearch.UseVisualStyleBackColor = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // LblReserve
            // 
            this.LblReserve.AutoSize = true;
            this.LblReserve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblReserve.Location = new System.Drawing.Point(24, 18);
            this.LblReserve.Name = "LblReserve";
            this.LblReserve.Size = new System.Drawing.Size(136, 20);
            this.LblReserve.TabIndex = 7;
            this.LblReserve.TabStop = true;
            this.LblReserve.Text = "Rezerviraj pregled";
            this.LblReserve.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblReserve_LinkClicked);
            // 
            // DgvExamination
            // 
            this.DgvExamination.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvExamination.BackgroundColor = System.Drawing.Color.White;
            this.DgvExamination.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvExamination.Location = new System.Drawing.Point(12, 152);
            this.DgvExamination.Name = "DgvExamination";
            this.DgvExamination.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvExamination.Size = new System.Drawing.Size(872, 293);
            this.DgvExamination.TabIndex = 8;
            this.DgvExamination.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DgvExamination_MouseDoubleClick);
            // 
            // LblEditProfile
            // 
            this.LblEditProfile.AutoSize = true;
            this.LblEditProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEditProfile.Location = new System.Drawing.Point(179, 18);
            this.LblEditProfile.Name = "LblEditProfile";
            this.LblEditProfile.Size = new System.Drawing.Size(85, 20);
            this.LblEditProfile.TabIndex = 9;
            this.LblEditProfile.TabStop = true;
            this.LblEditProfile.Text = "Uredi profil";
            this.LblEditProfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblEditProfile_LinkClicked);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BtnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRefresh.ForeColor = System.Drawing.Color.Black;
            this.BtnRefresh.Location = new System.Drawing.Point(770, 81);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(114, 43);
            this.BtnRefresh.TabIndex = 10;
            this.BtnRefresh.Text = "Osvjezi";
            this.BtnRefresh.UseVisualStyleBackColor = false;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // ChBoxPatient
            // 
            this.ChBoxPatient.AutoSize = true;
            this.ChBoxPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChBoxPatient.Location = new System.Drawing.Point(614, 93);
            this.ChBoxPatient.Name = "ChBoxPatient";
            this.ChBoxPatient.Size = new System.Drawing.Size(138, 24);
            this.ChBoxPatient.TabIndex = 11;
            this.ChBoxPatient.Text = "Uloga pacijenta";
            this.ChBoxPatient.UseVisualStyleBackColor = true;
            this.ChBoxPatient.CheckedChanged += new System.EventHandler(this.ChBoxPatient_CheckedChanged);
            // 
            // HomePageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(896, 505);
            this.Controls.Add(this.ChBoxPatient);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.LblEditProfile);
            this.Controls.Add(this.DgvExamination);
            this.Controls.Add(this.LblReserve);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.CmbDoctors);
            this.Controls.Add(this.DateReservation);
            this.Controls.Add(this.LblDoctor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblUsername);
            this.Name = "HomePageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomePageForm";
            this.Load += new System.EventHandler(this.HomePageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvExamination)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblDoctor;
        private System.Windows.Forms.DateTimePicker DateReservation;
        private System.Windows.Forms.ComboBox CmbDoctors;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.LinkLabel LblReserve;
        private System.Windows.Forms.DataGridView DgvExamination;
        private System.Windows.Forms.LinkLabel LblEditProfile;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.CheckBox ChBoxPatient;
    }
}

namespace ePregledi.WinUI.Forms.Examination
{
    partial class ExaminationDetailsForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PicProfileBox = new System.Windows.Forms.PictureBox();
            this.TxtDateReservation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtGender = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDateOfBirth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtFullName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Diagnose = new System.Windows.Forms.TabPage();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtDiagnoseName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Recipe = new System.Windows.Forms.TabPage();
            this.BtnOpenPdf = new System.Windows.Forms.Button();
            this.TxtPdfUploadbox = new System.Windows.Forms.TextBox();
            this.BtnUpload = new System.Windows.Forms.Button();
            this.TxtInstructions = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtMedicine = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Referral = new System.Windows.Forms.TabPage();
            this.PriorityNumberPicker = new System.Windows.Forms.NumericUpDown();
            this.TxtInformation = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicProfileBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Diagnose.SuspendLayout();
            this.Recipe.SuspendLayout();
            this.Referral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PriorityNumberPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.PicProfileBox);
            this.groupBox1.Controls.Add(this.TxtDateReservation);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtGender);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtDateOfBirth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtFullName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 479);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalji pacijenta";
            // 
            // PicProfileBox
            // 
            this.PicProfileBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PicProfileBox.Location = new System.Drawing.Point(33, 19);
            this.PicProfileBox.Name = "PicProfileBox";
            this.PicProfileBox.Size = new System.Drawing.Size(180, 180);
            this.PicProfileBox.TabIndex = 10;
            this.PicProfileBox.TabStop = false;
            // 
            // TxtDateReservation
            // 
            this.TxtDateReservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDateReservation.Location = new System.Drawing.Point(6, 431);
            this.TxtDateReservation.Name = "TxtDateReservation";
            this.TxtDateReservation.ReadOnly = true;
            this.TxtDateReservation.Size = new System.Drawing.Size(250, 26);
            this.TxtDateReservation.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 408);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Datum rezervacije";
            // 
            // TxtGender
            // 
            this.TxtGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtGender.Location = new System.Drawing.Point(6, 359);
            this.TxtGender.Name = "TxtGender";
            this.TxtGender.ReadOnly = true;
            this.TxtGender.Size = new System.Drawing.Size(250, 26);
            this.TxtGender.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Spol";
            // 
            // TxtDateOfBirth
            // 
            this.TxtDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDateOfBirth.Location = new System.Drawing.Point(6, 294);
            this.TxtDateOfBirth.Name = "TxtDateOfBirth";
            this.TxtDateOfBirth.ReadOnly = true;
            this.TxtDateOfBirth.Size = new System.Drawing.Size(250, 26);
            this.TxtDateOfBirth.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Datum rodjenja";
            // 
            // TxtFullName
            // 
            this.TxtFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFullName.Location = new System.Drawing.Point(6, 222);
            this.TxtFullName.Name = "TxtFullName";
            this.TxtFullName.ReadOnly = true;
            this.TxtFullName.Size = new System.Drawing.Size(250, 26);
            this.TxtFullName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime i prezime";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Diagnose);
            this.tabControl1.Controls.Add(this.Recipe);
            this.tabControl1.Controls.Add(this.Referral);
            this.tabControl1.Location = new System.Drawing.Point(299, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(812, 426);
            this.tabControl1.TabIndex = 1;
            // 
            // Diagnose
            // 
            this.Diagnose.Controls.Add(this.TxtDescription);
            this.Diagnose.Controls.Add(this.label7);
            this.Diagnose.Controls.Add(this.TxtDiagnoseName);
            this.Diagnose.Controls.Add(this.label6);
            this.Diagnose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Diagnose.Location = new System.Drawing.Point(4, 22);
            this.Diagnose.Name = "Diagnose";
            this.Diagnose.Padding = new System.Windows.Forms.Padding(3);
            this.Diagnose.Size = new System.Drawing.Size(804, 400);
            this.Diagnose.TabIndex = 0;
            this.Diagnose.Text = "Dijagnoza";
            this.Diagnose.UseVisualStyleBackColor = true;
            // 
            // TxtDescription
            // 
            this.TxtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescription.Location = new System.Drawing.Point(19, 116);
            this.TxtDescription.Multiline = true;
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.Size = new System.Drawing.Size(761, 225);
            this.TxtDescription.TabIndex = 5;
            this.TxtDescription.Validating += new System.ComponentModel.CancelEventHandler(this.TxtDescription_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Opis dijagnoze";
            // 
            // TxtDiagnoseName
            // 
            this.TxtDiagnoseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDiagnoseName.Location = new System.Drawing.Point(19, 33);
            this.TxtDiagnoseName.Name = "TxtDiagnoseName";
            this.TxtDiagnoseName.Size = new System.Drawing.Size(761, 26);
            this.TxtDiagnoseName.TabIndex = 3;
            this.TxtDiagnoseName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtDiagnoseName_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Naziv dijagnoze";
            // 
            // Recipe
            // 
            this.Recipe.Controls.Add(this.BtnOpenPdf);
            this.Recipe.Controls.Add(this.TxtPdfUploadbox);
            this.Recipe.Controls.Add(this.BtnUpload);
            this.Recipe.Controls.Add(this.TxtInstructions);
            this.Recipe.Controls.Add(this.label8);
            this.Recipe.Controls.Add(this.TxtMedicine);
            this.Recipe.Controls.Add(this.label9);
            this.Recipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Recipe.Location = new System.Drawing.Point(4, 22);
            this.Recipe.Name = "Recipe";
            this.Recipe.Padding = new System.Windows.Forms.Padding(3);
            this.Recipe.Size = new System.Drawing.Size(804, 400);
            this.Recipe.TabIndex = 1;
            this.Recipe.Text = "Recepti";
            this.Recipe.UseVisualStyleBackColor = true;
            // 
            // BtnOpenPdf
            // 
            this.BtnOpenPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnOpenPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpenPdf.ForeColor = System.Drawing.Color.Black;
            this.BtnOpenPdf.Location = new System.Drawing.Point(684, 352);
            this.BtnOpenPdf.Name = "BtnOpenPdf";
            this.BtnOpenPdf.Size = new System.Drawing.Size(87, 28);
            this.BtnOpenPdf.TabIndex = 12;
            this.BtnOpenPdf.Text = "Uputsvo";
            this.BtnOpenPdf.UseVisualStyleBackColor = false;
            this.BtnOpenPdf.Click += new System.EventHandler(this.BtnOpenPdf_Click);
            // 
            // TxtPdfUploadbox
            // 
            this.TxtPdfUploadbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPdfUploadbox.Location = new System.Drawing.Point(6, 354);
            this.TxtPdfUploadbox.Name = "TxtPdfUploadbox";
            this.TxtPdfUploadbox.Size = new System.Drawing.Size(552, 26);
            this.TxtPdfUploadbox.TabIndex = 11;
            // 
            // BtnUpload
            // 
            this.BtnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpload.ForeColor = System.Drawing.Color.Black;
            this.BtnUpload.Location = new System.Drawing.Point(577, 353);
            this.BtnUpload.Name = "BtnUpload";
            this.BtnUpload.Size = new System.Drawing.Size(87, 28);
            this.BtnUpload.TabIndex = 10;
            this.BtnUpload.Text = "Upload";
            this.BtnUpload.UseVisualStyleBackColor = false;
            this.BtnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // TxtInstructions
            // 
            this.TxtInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInstructions.Location = new System.Drawing.Point(21, 109);
            this.TxtInstructions.Multiline = true;
            this.TxtInstructions.Name = "TxtInstructions";
            this.TxtInstructions.Size = new System.Drawing.Size(750, 225);
            this.TxtInstructions.TabIndex = 9;
            this.TxtInstructions.Validating += new System.ComponentModel.CancelEventHandler(this.TxtInstructions_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Instrukcije";
            // 
            // TxtMedicine
            // 
            this.TxtMedicine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMedicine.Location = new System.Drawing.Point(21, 36);
            this.TxtMedicine.Name = "TxtMedicine";
            this.TxtMedicine.Size = new System.Drawing.Size(750, 26);
            this.TxtMedicine.TabIndex = 7;
            this.TxtMedicine.Validating += new System.ComponentModel.CancelEventHandler(this.TxtMedicine_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "Lijek";
            // 
            // Referral
            // 
            this.Referral.Controls.Add(this.PriorityNumberPicker);
            this.Referral.Controls.Add(this.TxtInformation);
            this.Referral.Controls.Add(this.label10);
            this.Referral.Controls.Add(this.label11);
            this.Referral.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Referral.Location = new System.Drawing.Point(4, 22);
            this.Referral.Name = "Referral";
            this.Referral.Size = new System.Drawing.Size(804, 400);
            this.Referral.TabIndex = 2;
            this.Referral.Text = "Uputnica";
            this.Referral.UseVisualStyleBackColor = true;
            // 
            // PriorityNumberPicker
            // 
            this.PriorityNumberPicker.Location = new System.Drawing.Point(21, 45);
            this.PriorityNumberPicker.Name = "PriorityNumberPicker";
            this.PriorityNumberPicker.Size = new System.Drawing.Size(751, 26);
            this.PriorityNumberPicker.TabIndex = 15;
            this.PriorityNumberPicker.Validating += new System.ComponentModel.CancelEventHandler(this.PriorityNumberPicker_Validating);
            // 
            // TxtInformation
            // 
            this.TxtInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInformation.Location = new System.Drawing.Point(21, 125);
            this.TxtInformation.Multiline = true;
            this.TxtInformation.Name = "TxtInformation";
            this.TxtInformation.Size = new System.Drawing.Size(751, 253);
            this.TxtInformation.TabIndex = 14;
            this.TxtInformation.Validating += new System.ComponentModel.CancelEventHandler(this.TxtInformation_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 20);
            this.label10.TabIndex = 13;
            this.label10.Text = "Informacije";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 20);
            this.label11.TabIndex = 11;
            this.label11.Text = "Prioritet";
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.Black;
            this.BtnSave.Location = new System.Drawing.Point(962, 448);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(149, 43);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "Sacuvaj";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(299, 462);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(114, 20);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Ocijeni doktora";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ExaminationDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 514);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ExaminationDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExaminationDetailsForm";
            this.Load += new System.EventHandler(this.ExaminationDetailsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicProfileBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Diagnose.ResumeLayout(false);
            this.Diagnose.PerformLayout();
            this.Recipe.ResumeLayout(false);
            this.Recipe.PerformLayout();
            this.Referral.ResumeLayout(false);
            this.Referral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PriorityNumberPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtDateReservation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtGender;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDateOfBirth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtFullName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Diagnose;
        private System.Windows.Forms.TabPage Recipe;
        private System.Windows.Forms.TabPage Referral;
        private System.Windows.Forms.TextBox TxtDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtDiagnoseName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.PictureBox PicProfileBox;
        private System.Windows.Forms.TextBox TxtInstructions;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtMedicine;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtInformation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.NumericUpDown PriorityNumberPicker;
        private System.Windows.Forms.TextBox TxtPdfUploadbox;
        private System.Windows.Forms.Button BtnUpload;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button BtnOpenPdf;
    }
}
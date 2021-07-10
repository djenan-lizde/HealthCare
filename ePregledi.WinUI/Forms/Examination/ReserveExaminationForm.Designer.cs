
namespace ePregledi.WinUI.Forms.Examination
{
    partial class ReserveExaminationForm
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
            this.BtnReserve = new System.Windows.Forms.Button();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.TimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbDoctors = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtRecomDoctor = new System.Windows.Forms.TextBox();
            this.CmbAmbulance = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbDepartment = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbRooms = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnReserve
            // 
            this.BtnReserve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BtnReserve.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReserve.ForeColor = System.Drawing.Color.Black;
            this.BtnReserve.Location = new System.Drawing.Point(602, 313);
            this.BtnReserve.Name = "BtnReserve";
            this.BtnReserve.Size = new System.Drawing.Size(149, 43);
            this.BtnReserve.TabIndex = 7;
            this.BtnReserve.Text = "Rezervisi";
            this.BtnReserve.UseVisualStyleBackColor = false;
            this.BtnReserve.Click += new System.EventHandler(this.BtnReserve_Click);
            // 
            // DatePicker
            // 
            this.DatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatePicker.Location = new System.Drawing.Point(48, 141);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(279, 24);
            this.DatePicker.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Datum rezervacije";
            // 
            // TimePicker
            // 
            this.TimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimePicker.Location = new System.Drawing.Point(48, 233);
            this.TimePicker.Name = "TimePicker";
            this.TimePicker.Size = new System.Drawing.Size(279, 24);
            this.TimePicker.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Vrijeme rezervacije";
            // 
            // CmbDoctors
            // 
            this.CmbDoctors.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDoctors.FormattingEnabled = true;
            this.CmbDoctors.Location = new System.Drawing.Point(49, 325);
            this.CmbDoctors.Name = "CmbDoctors";
            this.CmbDoctors.Size = new System.Drawing.Size(278, 26);
            this.CmbDoctors.TabIndex = 13;
            this.CmbDoctors.Validating += new System.ComponentModel.CancelEventHandler(this.CmbDoctors_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Doktor";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Prijedlog doktora";
            // 
            // txtRecomDoctor
            // 
            this.txtRecomDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtRecomDoctor.Location = new System.Drawing.Point(48, 62);
            this.txtRecomDoctor.Name = "txtRecomDoctor";
            this.txtRecomDoctor.ReadOnly = true;
            this.txtRecomDoctor.Size = new System.Drawing.Size(279, 24);
            this.txtRecomDoctor.TabIndex = 15;
            // 
            // CmbAmbulance
            // 
            this.CmbAmbulance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbAmbulance.FormattingEnabled = true;
            this.CmbAmbulance.Location = new System.Drawing.Point(473, 60);
            this.CmbAmbulance.Name = "CmbAmbulance";
            this.CmbAmbulance.Size = new System.Drawing.Size(278, 26);
            this.CmbAmbulance.TabIndex = 17;
            this.CmbAmbulance.SelectedIndexChanged += new System.EventHandler(this.CmbAmbulance_SelectedIndexChanged);
            this.CmbAmbulance.Validating += new System.ComponentModel.CancelEventHandler(this.CmbAmbulance_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(469, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Ambulanta";
            // 
            // CmbDepartment
            // 
            this.CmbDepartment.Enabled = false;
            this.CmbDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDepartment.FormattingEnabled = true;
            this.CmbDepartment.Location = new System.Drawing.Point(473, 141);
            this.CmbDepartment.Name = "CmbDepartment";
            this.CmbDepartment.Size = new System.Drawing.Size(278, 26);
            this.CmbDepartment.TabIndex = 19;
            this.CmbDepartment.SelectedIndexChanged += new System.EventHandler(this.CmbDepartment_SelectedIndexChanged);
            this.CmbDepartment.Validating += new System.ComponentModel.CancelEventHandler(this.CmbDepartment_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(469, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Odjel";
            // 
            // CmbRooms
            // 
            this.CmbRooms.Enabled = false;
            this.CmbRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbRooms.FormattingEnabled = true;
            this.CmbRooms.Location = new System.Drawing.Point(473, 231);
            this.CmbRooms.Name = "CmbRooms";
            this.CmbRooms.Size = new System.Drawing.Size(278, 26);
            this.CmbRooms.TabIndex = 21;
            this.CmbRooms.Validating += new System.ComponentModel.CancelEventHandler(this.CmbRooms_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(469, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "Soba";
            // 
            // ReserveExaminationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 416);
            this.Controls.Add(this.CmbRooms);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CmbDepartment);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CmbAmbulance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRecomDoctor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbDoctors);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TimePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DatePicker);
            this.Controls.Add(this.BtnReserve);
            this.Name = "ReserveExaminationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReserveExaminationForm";
            this.Load += new System.EventHandler(this.ReserveExaminationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnReserve;
        private System.Windows.Forms.DateTimePicker DatePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker TimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbDoctors;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtRecomDoctor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbRooms;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CmbDepartment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbAmbulance;
        private System.Windows.Forms.Label label5;
    }
}
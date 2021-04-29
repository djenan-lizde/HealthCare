
namespace ePregledi.WinUI.Forms.Examination
{
    partial class RateDoctorForm
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
            this.TxtComment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Ocjena = new System.Windows.Forms.Label();
            this.RateNumberPicker = new System.Windows.Forms.NumericUpDown();
            this.LblDoctor = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.RateNumberPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtComment
            // 
            this.TxtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtComment.Location = new System.Drawing.Point(24, 153);
            this.TxtComment.Multiline = true;
            this.TxtComment.Name = "TxtComment";
            this.TxtComment.Size = new System.Drawing.Size(750, 225);
            this.TxtComment.TabIndex = 13;
            this.TxtComment.Validating += new System.ComponentModel.CancelEventHandler(this.TxtComment_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Komentar";
            // 
            // Ocjena
            // 
            this.Ocjena.AutoSize = true;
            this.Ocjena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ocjena.Location = new System.Drawing.Point(20, 57);
            this.Ocjena.Name = "Ocjena";
            this.Ocjena.Size = new System.Drawing.Size(59, 20);
            this.Ocjena.TabIndex = 10;
            this.Ocjena.Text = "Ocjena";
            // 
            // RateNumberPicker
            // 
            this.RateNumberPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RateNumberPicker.Location = new System.Drawing.Point(23, 80);
            this.RateNumberPicker.Name = "RateNumberPicker";
            this.RateNumberPicker.Size = new System.Drawing.Size(751, 26);
            this.RateNumberPicker.TabIndex = 16;
            this.RateNumberPicker.Validating += new System.ComponentModel.CancelEventHandler(this.RateNumberPicker_Validating);
            // 
            // LblDoctor
            // 
            this.LblDoctor.AutoSize = true;
            this.LblDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDoctor.Location = new System.Drawing.Point(334, 21);
            this.LblDoctor.Name = "LblDoctor";
            this.LblDoctor.Size = new System.Drawing.Size(51, 20);
            this.LblDoctor.TabIndex = 17;
            this.LblDoctor.Text = "label1";
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.Black;
            this.BtnSave.Location = new System.Drawing.Point(625, 395);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(149, 43);
            this.BtnSave.TabIndex = 18;
            this.BtnSave.Text = "Sacuvaj";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // RateDoctorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.LblDoctor);
            this.Controls.Add(this.RateNumberPicker);
            this.Controls.Add(this.TxtComment);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Ocjena);
            this.Name = "RateDoctorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RateDoctorForm";
            this.Load += new System.EventHandler(this.RateDoctorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RateNumberPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtComment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Ocjena;
        private System.Windows.Forms.NumericUpDown RateNumberPicker;
        private System.Windows.Forms.Label LblDoctor;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
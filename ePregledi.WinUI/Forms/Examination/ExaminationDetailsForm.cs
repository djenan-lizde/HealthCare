using ePregledi.Models.Models;
using ePregledi.Models.Responses;
using ePregledi.WinUI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ePregledi.WinUI.Forms.Examination
{
    public partial class ExaminationDetailsForm : Form
    {
        private readonly APIService _apiServiceUser = new APIService("Users");
        private readonly APIService _apiServiceExamination = new APIService("Examinations");

        private int ExaminationId { get; set; }
        private int DoctorId { get; set; }
        private int PatientId { get; set; }
        byte[] pdfFile = null;
        ExaminationDetails ed = null;

        public ExaminationDetailsForm(int examinationId, int doctorId, int patientId)
        {
            InitializeComponent();
            ExaminationId = examinationId;
            DoctorId = doctorId;
            PatientId = patientId;
            AutoValidate = AutoValidate.Disable;
            linkLabel1.Visible = false;
        }
        private async void ExaminationDetailsForm_Load(object sender, EventArgs e)
        {
            try
            {
                BtnSave.Visible = false;
                TxtPdfUploadbox.ReadOnly = true;

                var medicine = await _apiServiceExamination.Get<List<Medicine>>(null, "medicines");

                medicine.Insert(0, new Medicine());
                CmbMedicine.DataSource = medicine;
                CmbMedicine.ValueMember = "Id";
                CmbMedicine.DisplayMember = "Name";

                var user = await _apiServiceUser.GetById<PatientViewModel>(PatientId, "patient");

                if (user == null)
                    return;

                if (APIService.Role == "Doctor")
                {
                    BtnSave.Visible = true;
                }

                TxtFullName.Text = user.FullName;
                TxtDateOfBirth.Text = user.DateOfBirth.ToString();
                TxtGender.Text = user.Gender.ToString();

                Image image = ImageResizer.ByteArrayToImage(user.Photo);
                var newImage = ImageResizer.ResizeImage(image, 180, 180);
                PicProfileBox.Image = newImage;

                var ex = await _apiServiceExamination.GetById<Models.Models.Examination>(ExaminationId);

                TxtDateReservation.Text = $"{ex.ExaminationDate:MM/dd/yyyy} {ex.ExaminationTime:hh\\:mm}";

                ed = await _apiServiceExamination.GetById<ExaminationDetails>(ExaminationId, "details");

                if (ed == null)
                {
                    MessageBox.Show("Nema detalja pregleda.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                linkLabel1.Visible = true;
                TxtDiagnoseName.Text = ed.Diagnosis.DiagnosisName;
                TxtDescription.Text = ed.Diagnosis.Description;
                CmbMedicine.SelectedItem = ed.Recipe.MedicineId;
                TxtInstructions.Text = ed.Recipe.Instruction;
                PriorityNumberPicker.Value = ed.Referral.Priority;
                TxtInformation.Text = ed.Referral.Info.ToString();
                pdfFile = ed.Recipe.PdfDocument;
            }
            catch (Exception)
            {
                MessageBox.Show("Doslo je do greske.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    var exDet = new ExaminationDetails
                    {
                        ExaminationId = ExaminationId,
                        ReservationDate = DateTime.Parse(TxtDateReservation.Text),
                        Diagnosis = new Diagnosis
                        {
                            DiagnosisName = TxtDiagnoseName.Text,
                            Description = TxtDescription.Text,
                            ExaminationId = ExaminationId
                        },
                        Recipe = new Recipe
                        {
                            MedicineId = int.Parse(CmbMedicine.SelectedValue.ToString()),
                            Instruction = TxtInstructions.Text,
                            DiagnosisId = 0,
                            PdfDocument = pdfFile
                        },
                        Referral = new Referral
                        {
                            Info = TxtInformation.Text,
                            Priority = (int)PriorityNumberPicker.Value,
                            ExaminationId = ExaminationId
                        }
                    };

                    await _apiServiceExamination.Insert<ExaminationDetails>(exDet, "details");

                    MessageBox.Show("Uspjesno sacuvano.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Doslo je do greske.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Molimo popunite sva polja", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void BtnOpenPdf_Click(object sender, EventArgs e)
        {
            Guid g = Guid.NewGuid();
            OpenInAnotherApp(pdfFile, $"{CmbMedicine.SelectedItem}_{g}.pdf");
        }
        private static void OpenInAnotherApp(byte[] data, string filename)
        {
            if (data != null)
            {
                var tempFolder = Path.GetTempPath();
                filename = Path.Combine(tempFolder, filename);
                File.WriteAllBytes(filename, data);
                Process.Start(filename);
            }
        }
        private void BtnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog Openpdf = new OpenFileDialog
            {
                Filter = "PDF files|*.pdf|All files|*.*;"
            };

            if (Openpdf.ShowDialog() == DialogResult.OK)
            {
                string pdfLog = Openpdf.FileName;
                var file = File.ReadAllBytes(pdfLog);
                TxtPdfUploadbox.Text = pdfLog;
                pdfFile = new byte[file.Length];
                pdfFile = file;
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RateDoctorForm frm = new RateDoctorForm(ExaminationId, DoctorId);
            frm.Show();
        }
        private void TxtDiagnoseName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtDiagnoseName.Text))
            {
                errorProvider1.SetError(TxtDiagnoseName, "Input can not be an empty string.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TxtDiagnoseName, null);
            }
        }
        private void TxtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtDescription.Text))
            {
                errorProvider1.SetError(TxtDescription, "Input can not be an empty string.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TxtDescription, null);
            }
        }
        private void TxtInstructions_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtInstructions.Text))
            {
                errorProvider1.SetError(TxtInstructions, "Input can not be an empty string.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TxtInstructions, null);
            }
        }
        private void TxtInformation_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtInformation.Text))
            {
                errorProvider1.SetError(TxtInformation, "Input can not be an empty string.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TxtInformation, null);
            }
        }
        private void PriorityNumberPicker_Validating(object sender, CancelEventArgs e)
        {
            if (PriorityNumberPicker.Value < 1)
            {
                errorProvider1.SetError(PriorityNumberPicker, "Value can't be lower than 1");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(PriorityNumberPicker, null);
            }
        }
    }
}

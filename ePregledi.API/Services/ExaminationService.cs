using AutoMapper;
using ePregledi.API.Database;
using ePregledi.Models.Models;
using ePregledi.Models.Requests;
using ePregledi.Models.Responses;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using static ePregledi.Models.Enums.Enums;

namespace ePregledi.API.Services
{
    public interface IExaminationService : IBaseService<Examination>
    {
        IEnumerable<ExaminationViewModel> GetExaminations(SearchExamination request);
        ExaminationDetails GetExaminationDetails(int examinationId);
        DoctorViewModel RecommendDoctor(int patientId);
    }
    public class ExaminationService : BaseService<Examination>, IExaminationService
    {
        public ExaminationService(
            ApplicationDbContext context,
            IMapper mapper
            ) : base(context, mapper)
        {
        }

        public IEnumerable<ExaminationViewModel> GetExaminations(SearchExamination request)
        {
            var query = _context.Examinations.AsQueryable();

            if (request.DeviceType == DeviceType.Desktop)
            {
                if (request.DoctorId != 0)
                    query = query.Where(x => x.DoctorId == request.DoctorId);

                if (request.PatientId != 0)
                    query = query.Where(x => x.PatientId == request.PatientId);
            }
            else if (request.DeviceType == DeviceType.Mobile)
            {
                if (request.PatientId != 0)
                {
                    query = _context.Examinations.Include(x => x.Doctor)
                            .Where(x => x.PatientId == request.PatientId && x.DoctorId == request.DoctorId);

                    return Data(query, request);
                }

                if (string.IsNullOrWhiteSpace(request.PatientFullName)
                    || string.IsNullOrEmpty(request.PatientFullName))
                {
                    query = _context.Examinations.Include(x => x.Doctor)
                        .Where(x => x.DoctorId == request.DoctorId);
                }
                else
                {
                    query = _context.Examinations.Include(x => x.Doctor)
                        .Where(x => (x.Patient.FirstName.Contains(request.PatientFullName) || x.Patient.LastName.Contains(request.PatientFullName)) && x.DoctorId == request.DoctorId);
                }
                return Data(query, request);
            }
            return Data(query, request);
        }

        private IEnumerable<ExaminationViewModel> Data(IQueryable<Examination> query, SearchExamination request)
        {
            return query
           .Where(x => x.ExaminationDate.Date == request.ExaminationDate.Date)
           .Select(x => new ExaminationViewModel
           {
               Id = x.Id,
               DoctorName = $"{x.Doctor.FirstName} {x.Doctor.LastName}",
               ExaminationDate = x.ExaminationDate.Date.ToString(),
               ExaminationTime = x.ExaminationTime.ToString(),
               PatientName = $"{x.Patient.FirstName} {x.Patient.LastName}",
               DoctorId = x.DoctorId,
               PatientId = x.PatientId,
           })
           .OrderByDescending(x => x.ExaminationDate);
        }

        public ExaminationDetails GetExaminationDetails(int examinationId)
        {
            var result = _context.Diagnoses.Include(x => x.Examination)
                .Where(x => x.ExaminationId == examinationId)
                .Select(x => new ExaminationDetails
                {
                    ExaminationId = examinationId,
                    ReservationDate = x.Examination.ExaminationDate,
                    Diagnosis = x,
                    Recipe = _context.Recipes.FirstOrDefault(y => y.DiagnosisId == x.Id),
                    Referral = _context.Referrals.FirstOrDefault(y => y.ExaminationId == examinationId)
                }).FirstOrDefault();
            return result;
        }
        public DoctorViewModel RecommendDoctor(int patientId)
        {
            var doctor = _context.Examinations
                .Include(x => x.Doctor)
                .Select(x => new DoctorViewModel
                {
                    DoctorId = x.DoctorId,
                    FirstName = x.Doctor.FirstName,
                    LastName = x.Doctor.LastName,
                    NumberOfExaminations = _context.Examinations.Count(y => y.PatientId == patientId && y.DoctorId == x.DoctorId)
                })
                .OrderByDescending(x => x.NumberOfExaminations)
                .Take(1)
                .FirstOrDefault();

            if (doctor != null && doctor.NumberOfExaminations > 0)
                return doctor;

            doctor = _context.Examinations
                .Include(x => x.Doctor)
                .Select(x => new DoctorViewModel
                {
                    DoctorId = x.DoctorId,
                    FirstName = x.Doctor.FirstName,
                    LastName = x.Doctor.LastName,
                    AverageRating = _context.Examinations.Where(y => y.DoctorId == x.DoctorId && y.Rating != 0).Average(y => y.Rating)
                })
                .OrderByDescending(x => x.AverageRating)
                .Take(1)
                .FirstOrDefault();

            if (doctor != null && doctor.AverageRating >= 1)
                return doctor;

            return _context.Examinations
                .Include(x => x.Doctor)
                .Select(x => new DoctorViewModel
                {
                    DoctorId = x.DoctorId,
                    FirstName = x.Doctor.FirstName,
                    LastName = x.Doctor.LastName,
                })
                .OrderByDescending(x => x.FirstName)
                .Take(1)
                .FirstOrDefault();
        }
    }
}

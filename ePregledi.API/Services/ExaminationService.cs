﻿using AutoMapper;
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

            if (request.DeviceType == DeviceType.Desktop && request.DoctorId != 0)
            {
                query = query.Where(x => x.DoctorId == request.DoctorId);
            }
            else if (request.DeviceType == DeviceType.Mobile)
            {
                if (string.IsNullOrEmpty(request.PatientFullName)
                    || string.IsNullOrWhiteSpace(request.PatientFullName))
                {
                    query = _context.Examinations.Include(x => x.Doctor)
                        .Where(x => x.ExaminationDate.Date == request.ExaminationDate.Date);
                }
                else
                {
                    query = _context.Examinations.Include(x => x.Doctor)
                        .Where(x => x.ExaminationDate.Date == request.ExaminationDate.Date
                         && (x.Patient.FirstName.Contains(request.PatientFullName) || x.Patient.LastName.Contains(request.PatientFullName)));
                }
                return query.Select(x => new ExaminationViewModel
                {
                    Id = x.Id,
                    DoctorName = $"{x.Doctor.FirstName} {x.Doctor.LastName}",
                    ExaminationDate = x.ExaminationDate.Date.ToString(),
                    ExaminationTime = x.ExaminationTime.ToString(),
                    PatientName = $"{x.Patient.FirstName} {x.Patient.LastName}",
                    DoctorId = x.DoctorId,
                    PatientId = x.PatientId,
                }).OrderByDescending(x => x.ExaminationDate);
            }
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
            DoctorViewModel doctor = _context.Examinations
                .Include(x => x.Doctor)
                .Select(x => new
                {
                    x.DoctorId,
                    x.Doctor.FirstName,
                    x.Doctor.LastName,
                    NumberOfExaminations = _context.Examinations.Count(y => y.PatientId == patientId && y.DoctorId == x.DoctorId)
                })
                .OrderByDescending(x => x.NumberOfExaminations)
                .GroupBy(x => x.DoctorId)
                .Take(1) as DoctorViewModel;

            if (doctor != null)
                return doctor;

            doctor = _context.Examinations
                .Include(x => x.Doctor)
                .Select(x => new
                {
                    x.DoctorId,
                    x.Doctor.FirstName,
                    x.Doctor.LastName,
                    AverageRating = _context.Examinations.Where(y => y.DoctorId == x.DoctorId).Average(y => y.Rating)
                })
                .GroupBy(x => x.DoctorId)
                .Take(1) as DoctorViewModel;

            if (doctor != null)
                return doctor;

            return _context.Examinations
                .Include(x => x.Doctor)
                .Select(x => new
                {
                    x.DoctorId,
                    x.Doctor.FirstName,
                    x.Doctor.LastName,
                })
                .OrderByDescending(x => x.FirstName)
                .Take(1) as DoctorViewModel;
        }
    }
}
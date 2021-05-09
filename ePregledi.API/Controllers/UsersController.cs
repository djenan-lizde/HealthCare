using AutoMapper;
using ePregledi.API.Services;
using ePregledi.Models.Models;
using ePregledi.Models.Requests;
using ePregledi.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ePregledi.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        private readonly IExaminationService _examinationService;

        public UsersController(
            IUserService userService,
            IUserRoleService userRoleService,
            IMapper mapper,
            IExaminationService examinationService
            )
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _mapper = mapper;
            _examinationService = examinationService;
        }

        [HttpPost("registration")]
        [AllowAnonymous]
        public UserRegistrationResult UserRegister(UserRegistrationModel userRequest)
        {
            return _userService.RegisterUser(userRequest);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(UserLoginModel model)
        {
            var user = _userService.Authenticate(model);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            return Ok(user);
        }

        [HttpGet("info/{userId}")]
        public UserEditViewModel GetExamination(int userId)
        {
            var user = _userService.GetById(userId);
            return _mapper.Map<UserEditViewModel>(user);
        }

        [HttpPut("edit")]
        public UserEditViewModel EditUser(UserEditViewModel userEdit)
        {
            var user = _userService.GetById(userEdit.UserId);

            var updatedUser = _userService.Update(new User
            {
                Id = user.Id,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Email = userEdit.Email,
                FirstName = userEdit.FirstName,
                LastName = userEdit.LastName,
                JoinDate = user.JoinDate,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
                PhoneNumber = userEdit.PhoneNumber,
                Photo = userEdit.Photo ?? new byte[0],
                Username = userEdit.Username
            }, user.Id);

            return _mapper.Map<UserEditViewModel>(updatedUser);
        }

        [HttpGet("patient/{patientId}")]
        public PatientViewModel GetPatient(int patientId)
        {
            var patient = _userService.GetById(patientId);
            return _mapper.Map<PatientViewModel>(patient);
        }

        [HttpGet("doctor/{doctorId}")]
        public DoctorViewModel GetDoctor(int doctorId)
        {
            var patient = _userService.GetById(doctorId);
            return _mapper.Map<DoctorViewModel>(patient);
        }

        [HttpGet("doctors")]
        public List<DoctorViewModel> GetDoctors()
        {
            var users = _userRoleService.Get();
            return _mapper.Map<List<DoctorViewModel>>(users);
        }

        [HttpGet("doctor/recommend/{patientId}")]
        public DoctorViewModel RecommendDoctor([FromRoute] int patientId)
        {
            var doctor = _examinationService.RecommendDoctor(patientId);

            if (doctor == null)
                return null;

            return new DoctorViewModel { DoctorId = doctor.DoctorId, FirstName = doctor.FirstName, LastName = doctor.LastName };
        }
    }
}

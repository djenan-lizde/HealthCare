using AutoMapper;
using ePregledi.API.Configuration;
using ePregledi.API.Database;
using ePregledi.API.Encryption;
using ePregledi.Models.Models;
using ePregledi.Models.Requests;
using ePregledi.Models.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using static ePregledi.Models.Enums.Enums;

namespace ePregledi.API.Services
{
    public interface IUserService : IBaseService<User>
    {
        UserAuthenticationResult Authenticate(UserLoginModel userLoginmodel);
        UserRegistrationResult RegisterUser(UserRegistrationModel userRegister);
    }
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IOptions<AppSettings> _options;
        private readonly IMapper _mapper;
        private readonly IUserRoleService _userRoleService;
        public UserService(
            ApplicationDbContext context,
            IOptions<AppSettings> options,
            IMapper mapper,
            IUserRoleService userRoleService) : base(context, mapper)
        {
            _options = options;
            _mapper = mapper;
            _userRoleService = userRoleService;
        }
        public UserAuthenticationResult Authenticate(UserLoginModel userLoginmodel)
        {
            var user = _context.Users
                .FirstOrDefault(x => x.Username == userLoginmodel.Username);

            if (user == null)
                return null;

            if (user.PasswordHash != HashGenSalt.GenerateHash(user.PasswordSalt, userLoginmodel.Password))
                return null;

            var role = _userRoleService.GetTByCondition(x => x.UserId == user.Id);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, role.Role.ToString())
                }),
                Issuer = _options.Value.Issuer,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserAuthenticationResult
            {
                Id = user.Id,
                Token = tokenHandler.WriteToken(token),
                Username = user.Username,
                Role = role.Role.ToString()
            };
        }
        public UserRegistrationResult RegisterUser(UserRegistrationModel userRegister)
        {
            var userInDbUserName = _context.Users.FirstOrDefault(x => x.Username == userRegister.Username);
            var userInDbEmail = _context.Users.FirstOrDefault(x => x.Email == userRegister.Email);

            if (userInDbUserName != null)
                throw new Exception("Username already in use!");

            if (userInDbEmail != null)
                throw new Exception("Email already in use!");

            if (userRegister.Password != userRegister.PasswordConfirmation)
            {
                throw new Exception("Passwords do not match!");
            }

            var user = new User
            {
                Email = userRegister.Email,
                Username = userRegister.Username,
                FirstName = userRegister.FirstName,
                LastName = userRegister.LastName,
                JoinDate = DateTime.Now,
                DateOfBirth = userRegister.DateOfBirth,
                Gender = userRegister.Gender,
                PhoneNumber = userRegister.PhoneNumber,
                Photo = userRegister.Photo ?? new byte[0]
            };

            user.PasswordSalt = HashGenSalt.GenerateSalt();
            user.PasswordHash = HashGenSalt.GenerateHash(user.PasswordSalt, userRegister.Password);

            _context.Users.Add(user);
            _context.SaveChanges();

            var role = _userRoleService.Insert(new UserRole
            {
                UserId = user.Id,
                Role = Role.Patient
            });

            var newUser = _mapper.Map<UserRegistrationResult>(user);

            newUser.Role = role.Role;

            return newUser;
        }
    }
}

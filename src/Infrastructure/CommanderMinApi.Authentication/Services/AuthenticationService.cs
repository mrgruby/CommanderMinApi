using CommanderMinApi.Application.Contracts.Persistence.Authentication;
using CommanderMinApi.Application.RequestModels.Authentication;
using CommanderMinApi.Application.ServiceResponses;
using CommanderMinApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Authentication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IUserRepository userRepo, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _configuration = configuration;
        }
        public async Task<ServiceResponse<string>> Authenticate(AuthenticationRequest authRequest)
        {
            var response = new ServiceResponse<string>();

            var user = await _userRepo.GetCommanderUser(authRequest.UserName);
            if (user == null)
            {
                response.Message = "User Not Found!";
                response.Success = false;
            }
            else if (user != null && !VerifyPasswordHash(authRequest.Password, user.PasswordHash, user.PasswordSalt))
            {
                response.Message = "Incorrect username or password!";
                response.Success = false;
            }
            else
            {
                response.Success = true;
                response.Data = CreateToken(user);
            }
            return response;
        }

        public async Task<ServiceResponse<Guid>> Register(RegistrationRequest registerRequest)
        {
            var response = new ServiceResponse<Guid>();
            var user = await _userRepo.GetCommanderUser(registerRequest.UserName);
            if (user != null)
            {
                response.Message = "User already exists!";
                response.Success = false;
            }
            
            var passwordHash = CreatePasswordHash(registerRequest.Password);
            var newUser = new CommanderUser
            {
                PasswordHash = passwordHash.passwordHash,
                PasswordSalt = passwordHash.passwordSalt,
                UserName = registerRequest.UserName
            };
            _userRepo.AddUser(newUser);
            response.Message = "User registered successfullly!";
            response.Data = newUser.Id;
            return response;
        }

        public async Task<ServiceResponse<Guid>> ChangePassword(ChangePasswordRequest changePasswordRequest)
        {
            var response = new ServiceResponse<Guid>();
            var user = await _userRepo.GetCommanderUser(changePasswordRequest.UserName);

            if (user == null)
            {
                response.Message = "User Not Found!";
                response.Success = false;
            }
            else if (user != null && !VerifyPasswordHash(changePasswordRequest.Password, user.PasswordHash, user.PasswordSalt))
            {
                response.Message = "Incorrect password!";
                response.Success = false;
            }
            var passwordHash = CreatePasswordHash(changePasswordRequest.NewPassword);

            user.PasswordHash = passwordHash.passwordHash;
            user.PasswordSalt = passwordHash.passwordSalt;

            _userRepo.Update(user);
            response.Message = "Password successfullly changed!";
            response.Data = user.Id;
            return response;

        }

        /// <summary>
        /// Create passwordhash and passwordsalt based on password. This method uses a Tuple to return multiple values, instead of using out parameters,
        /// </summary>
        /// <param name="password"></param>
        /// <returns>A Tuple with passwordhash and passwordsalt</returns>
        private (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                return (hmac.ComputeHash(Encoding.UTF8.GetBytes(password)), hmac.Key);
            }
        }

        /// <summary>
        /// Create a hash from the given password and compare that with the one from the database,
        /// to verify that the user has a valid password.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        /// <returns></returns>
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(CommanderUser user)
        {
            //These are claims that are stored in the JSON Web token
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)//This is used in pages like this - @context.User.Identity.Name
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<bool> UserExists(string userName)
        {
            var user = await _userRepo.GetCommanderUser(userName);
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}

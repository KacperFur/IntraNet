using IntraNet.Entities;
using IntraNet.Exceptions;
using IntraNet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IntraNet.Services
{
    public class AccountService : IAccountService
    {
        private readonly AuthenticationSetting _authenticationSetting;
        private readonly IntraNetDbContext _context;
        private readonly IPasswordHasher<Employee> _passwordHasher;

        public AccountService(IntraNetDbContext context, IPasswordHasher<Employee> passwordHasher, AuthenticationSetting authenticationSetting)
        {
            _authenticationSetting = authenticationSetting;
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public async Task<string> GenerateJwt(LoginDto dto)
        {
            var user = await _context.Employees
                .Include(e=> e.Role)
                .FirstOrDefaultAsync(e=> e.Email == dto.Email);
            if(user is null)
            {
                throw new BadRequestException("Invalid email address or password");
            }

           var result = _passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password);
            if(result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid email address or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSetting.JwtKey));
            var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSetting.JwtExpireDays);


            var token = new JwtSecurityToken(_authenticationSetting.JwtIssuer, _authenticationSetting.JwtIssuer,
                claims, expires: expires, signingCredentials: cred);


            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}

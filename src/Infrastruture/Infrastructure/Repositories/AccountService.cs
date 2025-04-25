using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.Repositores;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Persistance.IdentityModel;

namespace Infrastructure.Repositories
{
    public class AccountService : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;

        public AccountService(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        public async Task<AuthenticationResponse> LoginUser(LoginUserDTO registerUser)
        {
            var user=await userManager.FindByEmailAsync(registerUser.Email);
            if (user == null)
            {
                 throw new ArgumentException("User email cannot be empty");
            }
            var result =await signInManager.PasswordSignInAsync(user,registerUser.Password,false,false);
            if (!result.Succeeded)
            {
                throw new ArgumentException("passworn is incorrect");
            }
            var token = GenerateToken(user);
            var response = new AuthenticationResponse();
            response.Id = user.Id;
            response.UserName = user.UserName;
            response.Email = user.Email;
            response.IsVarified=user.EmailConfirmed=true;
            var role=await userManager.GetRolesAsync(user);
            response.Roles = role.ToList();
            response.JwtToken = token;

            return response;

           
        }

        private string GenerateToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                // Add any additional claims if needed
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])); // Retrieve your secret key from appsettings
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1), // Set expiration time for token
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> RegiterUser(RegisterUserDTO registerUser)
        {
            if (registerUser == null) { 
            
            throw new NotImplementedException("user must enter the values");
            }

            var user = await userManager.FindByEmailAsync(registerUser.Email);
            if (user != null)
            {
                throw new NotImplementedException("user already exist");
            }

            var newUser = new ApplicationUser();
            newUser.Id = Guid.NewGuid().ToString();
            newUser.UserName = registerUser.Email;
            newUser.Email = registerUser.Email;
            newUser.FirstName = registerUser.FirstName;
            newUser.LasrName=registerUser.LastName;
            newUser.Gender = registerUser.Gender;
            var result=await userManager.CreateAsync(newUser,registerUser.Password);
            if (!result.Succeeded)
            {
                return false;
            }
            else
            {

            return true;
            }

        }
    }
}

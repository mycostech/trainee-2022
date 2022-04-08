#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoapp_api.Data;
using todoapp_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using todoapp_api.Contract.Auth;
using System.Text;
using todoapp_api.Services;

namespace todoapp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return Ok(new
                {
                    Success = true,
                    Message = "Successfully login",
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Register model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return BadRequest(new Response { Success = false, Message = "User already exists!" });

            User user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Name
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return BadRequest(new Response { Success = false, Message = "User creation failed! Please check user details and try again.", Object = result.Errors });

            return Ok(new Response { Success = true, Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPassword model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists == null)
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Success = false, Message = "User does not exist" });

            var token = await _userManager.GeneratePasswordResetTokenAsync(userExists);
            var passwordResetLink = Url.Action("ResetPassword", "Auth", new { email = model.Email, token = token }, Request.Scheme);
            
            // EmailSender.SendEmailAsync() // this should be implement to send email to user

            return Ok(new { Success = true, Message = "Successfully send the reset password link to " + model.Email , Link = passwordResetLink, Token = token});
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordBody body, [FromQuery] ResetPasswordQuery query)
        {
            var user = await _userManager.FindByEmailAsync(query.Email);
            if (user == null)
                return BadRequest(new Response { Success = false, Message = "User does not exist" });
            if (body.Password != body.ConfirmPassword)
                return BadRequest(new Response { Success = false, Message = "Password does not match" });
            var result = await _userManager.ResetPasswordAsync(user, query.Token, body.Password);
            if (!result.Succeeded)
                return BadRequest(new { Success = false, Error = result.Errors });
            return Ok(new Response { Success = true, Message = "Successfully reset the password"});
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }
}

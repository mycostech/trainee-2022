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
using todoapp_api.Services.Interfaces;

namespace todoapp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            try
            {
                var user = await _userService.GetUserByEmailAsync(model.Email);
                if (user == null)
                    return StatusCode(StatusCodes.Status400BadRequest, new Response { Success = false, Message = "User does not exist" });
                if (!await _userService.CheckPasswordAsync(user, model.Password))
                    return StatusCode(StatusCodes.Status400BadRequest, new Response { Success = true, Message = "Credentials do not match" });

                var token = _userService.GenerateJWTToken(user);
                return Ok(new { Success = true, Message = "Successfully login", token = token });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message});
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Register model)
        {
            try
            {
                var user = await _userService.GetUserByEmailAsync(model.Email);
                if (user != null)
                    return BadRequest(new Response { Success = false, Message = "User already exists!" });

                var result = await _userService.CreateNewUserAsync(model.Email, model.Name, model.Password);
                if (!result.Succeeded)
                    return BadRequest(new Response { Success = false, Message = "User creation failed! Please check user details and try again.", Object = result.Errors });

                return Ok(new Response { Success = true, Message = "User created successfully!" });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
            
        }

        [HttpPost]
        [Route("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPassword model)
        {
            try
            {
                var user = await _userService.GetUserByEmailAsync(model.Email);
                if (user == null)
                    return StatusCode(StatusCodes.Status400BadRequest, new Response { Success = false, Message = "User does not exist" });

                var token = await _userService.GeneratePasswordResetTokenAsync(user);
                var passwordResetLink = Url.Action("ResetPassword", "Auth", new { email = model.Email, token = token }, Request.Scheme);

                // EmailSender.SendEmailAsync() // this should be implement to send email to user 

                return Ok(new
                {
                    Success = true,
                    Message = "Successfully send the reset password link to " + model.Email
                    ,
                    Link = passwordResetLink // this should be remove on production
                    ,
                    Token = token // this should be remove on production
                });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordBody body, [FromQuery] ResetPasswordQuery query)
        {
            try
            {
                var user = await _userService.GetUserByEmailAsync(query.Email);
                if (user == null)
                    return BadRequest(new Response { Success = false, Message = "User does not exist" });
                if (body.Password != body.ConfirmPassword)
                    return BadRequest(new Response { Success = false, Message = "Password does not match" });
                var result = await _userService.ResetPasswordAsync(user, query.Token, body.Password);
                if (!result.Succeeded)
                    return BadRequest(new { Success = false, Error = result.Errors });
                return Ok(new Response { Success = true, Message = "Successfully reset the password" });
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = ex.Message });
            }
        }

    }
}

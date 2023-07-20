using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Models;
using SchoolManagement.API.Repository;
using SchoolManagement.API.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        public LoginController(ILoginRepository LoginRepository)
        {
            _loginRepository = LoginRepository;
        }

        //Api Call for Login Table

        [HttpGet("")]

        public async Task<IActionResult> GetAllLogin()
        {
            var logins = await _loginRepository.GetAllLogins();
            if (logins == null)
            {
                return NotFound();
            }
            return Ok(logins);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetLoginById([FromRoute] int id)
        {
            var login = await _loginRepository.GetLoginbyId(id);
            if (login == null)
            {
                return NotFound();
            }
            return Ok(login);
        }

        [HttpPost("add")]

        public async Task<IActionResult> AddNewLogin([FromBody] LoginModel login)
        {
            var id = await _loginRepository.AddNewLogin(login);
            return CreatedAtAction(nameof(GetLoginById), new { id = id, controller = "Login" }, id);
        } 

        [HttpPost("authentication")]

        public async Task<IActionResult> LoginRole([FromBody] LoginModel roleObj)
        {
            if (roleObj == null)
                return BadRequest();

            var role = await _loginRepository.AddAuthentication(roleObj);
            if (role == null)
            {
                return NotFound(new { Message = "User Not Found!" });
            }

            role.Token = CreateJwt(role);
            return Ok(new
            {
                Token = role.Token,
                Message = "Login Success!"
            });

        }

        /*[HttpPut("update/{id}")]

        public async Task<IActionResult> UpdateLogin([FromBody] LoginModel loginModel, [FromRoute] int id)
        {
            await _loginRepository.UpdateLogin(id, loginModel);
            return Ok();
        }


        [HttpPatch("patch/{id}")]

        public async Task<IActionResult> UpdateLoginPatch([FromBody] JsonPatchDocument loginModel, [FromRoute] int id)
        {
            await _loginRepository.UpdateLoginPatch(id, loginModel);
            return Ok();
        }

        [HttpDelete("delete/{id}")]

        public async Task<IActionResult> DeleteLogin([FromRoute] int id)
        {
            await _loginRepository.DeleteLogin(id);
            return Ok();
        }*/
       private string CreateJwt(LoginTable login)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, login.IsUser),
                new Claim(ClaimTypes.Email,$"{login.LoginEmailId}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}

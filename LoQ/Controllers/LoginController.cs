using LoQ.BLL.DTO;
using LoQ.BLL.MediatR.Questionnaire.Get;
using LoQ.BLL.MediatR.User.GetByLoginParams;
using LoQ.Controllers.BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoQ.Controllers
{
    public class LoginController : BaseApiController
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var user = await AuthenticateAsync(login);

            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            return NotFound("User not found");
        }

        private async Task<UserDTO> AuthenticateAsync(LoginDTO login)
        {
            ActionResult result = HandleResult(await Mediator.Send(new GetUsersByLoginParamsQuery(login.Username, login.Password)));

            if (result is OkObjectResult okResult && okResult.Value is UserDTO user)
            {
                return user;
            }

            return null;
        }

        private string Generate(UserDTO user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        
        }
    }
}

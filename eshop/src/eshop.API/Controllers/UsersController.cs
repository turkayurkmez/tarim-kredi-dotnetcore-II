using eshop.API.Models;
using eshop.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(UserLoginInfoModel userLoginInfo)
        {
            if (ModelState.IsValid)
            {
                var user = userService.ValidateUser(userLoginInfo.UserName, userLoginInfo.Password);

                if (user != null) {
                    //burada token oluşturulacak!

                    SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("dönülmez-akşamın-ufkundayım-vakit-çok-geç"));

                    SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var claims = new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Role),
                        new Claim("Takim","EkmekSpor")

                    };
                    var token = new JwtSecurityToken(
                        issuer: "server",
                        audience: "client",
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddHours(12),
                        signingCredentials: signingCredentials
                        );

                    var tokenHandler = new JwtSecurityTokenHandler();
                    return Ok(new { token = tokenHandler.WriteToken(token) });
                }

                ModelState.AddModelError("InvalidCredentials", "Invalid username or password");
            }
          

            return BadRequest(ModelState);
        }
    }
}

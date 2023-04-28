using EVMS.Entities;
using EVMS.Models;
using EVMS.utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EVMS.Controllers
{
    public class AuthController : Controller
    {
        readonly AppSettings _appSettings;

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public JsonResult Authenticate([FromBody] User model)
        {
            var dbContext = new DatabaseContext();
            var user = dbContext.User.Where(u => u.username.Equals(model.username) && u.password.Equals(model.password)).FirstOrDefault();
            if (user == null)
            {
                return Json(new { msg = Constants.UserNamePasswordMessage });
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                int hrs = DateTime.UtcNow.Hour - 1;
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name,user.id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(24 - hrs), //DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                UserViewModel vm = new UserViewModel();
                vm.id = user.id;
                vm.name = user.name;
                vm.username = user.username;
                vm.isFirstApiCall = true;
                vm.apiCallJwtExpire = tokenDescriptor.Expires.Value;
                vm.Token = user.Token;
                return Json(vm);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using SignalRApplication.Service.Interfaces;
using SignalRApplication.Service.ViewModels;

namespace SignalRApplication.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;
        private IConfiguration _config;

        public LoginController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost, Route("get-login")]
        public JsonResult GetToken([FromBody]JObject clientData)
        {
            // check user exists in database if have database
            string UserName = clientData["UserName"].ToString();
            string PassWord = clientData["PassWord"].ToString();

            UserViewModel result = _userService.Login(UserName, PassWord);

            string token = "";
            if(result != null)
            {
                token = CreateToken(result);
            }
            else
            {
                token = "Unauthenticated!";
            }

            return new JsonResult(token);
        }

        private string CreateToken(UserViewModel model)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("UserName", model.username),
                new Claim("UserId", model.iduser)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], claims, expires: DateTime.Now.AddHours(8), signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
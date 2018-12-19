using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using App.Services;
using App.Services.Dto;
using IdentityModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using YF.Utility.Secutiry;




namespace DotNetCore_iViewAdmin_demo.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class LoginAccessController : ControllerBase
    {
        private IOptions<JwtSetting> _jwtsetting;
        private ILoginAccess _service;
        public LoginAccessController(IOptions<JwtSetting> jwtsetting)
        {
            _jwtsetting = jwtsetting;
            _service=new LoginAccessService();
        }

        // GET: api/LoginAccess
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
      
        [HttpPost]
        [Route("Login")]
        public IActionResult PostLogin(dynamic data)
        {          
            var userName = Convert.ToString(data.userName);
            var password = HashHelper.GetMd5(Convert.ToString(data.password));

            UserInfoDto loginUser = _service.Login(userName, password);           
            if (loginUser == null) return Unauthorized();

            User user = new User()
            {
                name = loginUser.UserName,
                user_id = loginUser.Id,
                access = new []{""},
                avator = "https://file.iviewui.com/dist/a0e88e83800f138b94d2414621bd9704.png"
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsetting.Value.SecurityKey);
            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddHours(1);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtClaimTypes.Audience,_jwtsetting.Value.Audience),
                    new Claim(JwtClaimTypes.Issuer,_jwtsetting.Value.Issuer),
                    new Claim(JwtClaimTypes.Id, loginUser.Id.ToString()),
                    new Claim(JwtClaimTypes.Name, loginUser.LoginId),
                   // new Claim(JwtClaimTypes.Expiration, expiresAt.ToString()),
                }),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            user.token = tokenString;

            return Ok(new
            {
                //access_token = tokenString,
               // token_type = "Bearer",
                loginUser=user,
                RefreshToken=Guid.NewGuid(),
                // expires_at = new DateTimeOffset(expiresAt).ToUnixTimeSeconds()
                //profile = new
                //{
                //    auth_time = new DateTimeOffset(authTime).ToUnixTimeSeconds(),
                //    expires_at = new DateTimeOffset(expiresAt).ToUnixTimeSeconds()
                //}
            });

        }

        // POST: api/LoginAccess
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/LoginAccess/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

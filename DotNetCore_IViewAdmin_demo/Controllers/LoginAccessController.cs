using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using App.Services.Dto;
using IdentityModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace DotNetCore_iViewAdmin_demo.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class LoginAccessController : ControllerBase
    {
        private IOptions<JwtSetting> _jwtsetting;
        public LoginAccessController(IOptions<JwtSetting> jwtsetting)
        {
            _jwtsetting = jwtsetting;
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

            //var builder = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json");
            //var configuration = builder.Build();

            var userName = Convert.ToString(data.userName);
            var password = Convert.ToString(data.password);
            User user = null;
            if (userName.ToString() == "super_admin" && password.ToString() == "1qaz2wsx")
            {
                user= new User()
                {
                    name = "super_admin",
                    user_id = 1,
                    access = new string[] { "super_admin", "admin" },
                    token = "super_admin",
                    avator = "https://file.iviewui.com/dist/a0e88e83800f138b94d2414621bd9704.png"
                };
            }
            else if (userName.ToString() == "admin" && password.ToString() == "123456")
            {
                user= new User()
                {
                    name = "admin",
                    user_id = 2,
                    access = new string[] { "admin" },
                    token = "admin",
                    avator = "https://avatars0.githubusercontent.com/u/20942571?s=460&v=4"
                };
            }
            if (user == null) return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsetting.Value.SecurityKey);
            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddMinutes(3);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtClaimTypes.Audience,_jwtsetting.Value.Audience),
                    new Claim(JwtClaimTypes.Issuer,_jwtsetting.Value.Issuer),
                    new Claim(JwtClaimTypes.Id, user.user_id.ToString()),
                    new Claim(JwtClaimTypes.Name, user.name),
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

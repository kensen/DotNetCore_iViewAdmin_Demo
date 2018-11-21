using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore_iViewAdmin_demo.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class LoginAccessController : ControllerBase
    {
        // GET: api/LoginAccess
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LoginAccess/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("Login")]
        public User PostLogin(dynamic data)
        {
            var userName = Convert.ToString(data.userName);
            var password = Convert.ToString(data.password);

            if (userName.ToString() == "super_admin" && password.ToString() == "1qaz2wsx")
            {
                return new User()
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
                return new User()
                {
                    name = "admin",
                    user_id = 2,
                    access = new string[] { "admin" },
                    token = "admin",
                    avator = "https://avatars0.githubusercontent.com/u/20942571?s=460&v=4"
                };
            }
            else
            {
                return null;
            }
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

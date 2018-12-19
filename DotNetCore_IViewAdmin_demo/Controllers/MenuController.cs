using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using App.Services;
using App.Services.Dto;
using YF.Utility.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace DotNetCore_iViewAdmin_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private ILoginAccess _service;

        public MenuController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _service = new LoginAccessService();
        }
        // GET: api/Menu
        [HttpGet()]
        [Authorize]
        public Array Get()
        {

            var identity = User.Identity as ClaimsIdentity;
          var id=  identity.Claims.Where(a => a.Type == "id").Select(a => a.Value).FirstOrDefault();

            var loginuser = _service.GetDto(id.ToInt());

            List<MenuDto> dtos =new List<MenuDto>();

            if (loginuser!=null && loginuser.UserType==0)
            {
              // var userAssertion = new UserAssertion(userAccessToken);
                string webRootPath = _hostingEnvironment.WebRootPath;
                string contentRootPath = _hostingEnvironment.ContentRootPath;
                var file = contentRootPath + ("\\menusetting.json");
                IFileProvider fileProvider = new PhysicalFileProvider(contentRootPath);
                byte[] buffer;
                using (Stream readStream = fileProvider.GetFileInfo("menusetting.json").CreateReadStream())
                {
                    buffer = new byte[readStream.Length];
                    readStream.Read(buffer, 0, buffer.Length);
                }
                var jsonstr = Encoding.UTF8.GetString(buffer);

                //var builder = new ConfigurationBuilder()
                //    .AddJsonFile("menusetting.json");
                //var configuration = builder.Build();
                //var t = configuration.Get<MenuDto>();
                var jobj = JObject.Parse(jsonstr);

                dtos = JsonConvert.DeserializeObject<List<MenuDto>>(jobj["menuSetting"].ToString(), new JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

               
            }
            else if(loginuser != null && loginuser.UserType==1)
            {
                //var jobj = JObject.Parse(loginuser.Authority);
                dtos = JsonConvert.DeserializeObject<List<MenuDto>>(loginuser.Authority, new JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
                dtos = dtos.Where(a => a.Show == true).ToList();
                foreach (var item in dtos)
                {
                    item.Children = item.Children.Where(a => a.Show == true).ToList();
                }

                // return dtos;
            }
            return dtos.ToArray();

        }


        [HttpGet()]
        [Authorize]
        [Route("GetBaseMenu")]
        public Array GetBaseMenu()
        {

            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var file = contentRootPath + ("\\menusetting.json");
            IFileProvider fileProvider = new PhysicalFileProvider(contentRootPath);
            byte[] buffer;
            using (Stream readStream = fileProvider.GetFileInfo("menusetting.json").CreateReadStream())
            {
                buffer = new byte[readStream.Length];
                readStream.Read(buffer, 0, buffer.Length);
            }
            var jsonstr = Encoding.UTF8.GetString(buffer);
            var jobj = JObject.Parse(jsonstr);
            List<MenuDto> dtos = JsonConvert.DeserializeObject<List<MenuDto>>(jobj["menuSetting"].ToString(), new JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });

            return dtos.ToArray();
        }

        // GET: api/Menu/5
        [HttpGet("{id}", Name = "GetMenu")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Menu
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Menu/5
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

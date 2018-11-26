using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Services.Dto;
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

        public MenuController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        // GET: api/Menu
        [HttpGet()]
        public Array Get()
        {

            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var file = contentRootPath + ("\\menusetting.json");
            IFileProvider  fileProvider=new PhysicalFileProvider(contentRootPath);
            byte[] buffer;
                using (Stream readStream = fileProvider.GetFileInfo("menusetting.json").CreateReadStream())
                       {
                         buffer = new byte[readStream.Length];
                           readStream.Read(buffer, 0, buffer.Length);
                        }
          var jsonstr=        Encoding.UTF8.GetString(buffer);

            //var builder = new ConfigurationBuilder()
            //    .AddJsonFile("menusetting.json");
            //var configuration = builder.Build();
            //var t = configuration.Get<MenuDto>();
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

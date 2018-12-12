using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services;
using App.Services.Dto;
using Comba.Base.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCore_iViewAdmin_demo.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        public SQLConnection LinkSQL;
        public TestController(IOptions<SQLConnection> conection)
        {
            LinkSQL = conection.Value;
        }
        // GET: api/<controller>
        [HttpGet]
        public List<BaseUsersDto> Get()
        {
            var taskservice = new BaseUsersService();

            List<QueryBuilder> qbList=new List<QueryBuilder>();
            qbList.Add(new QueryBuilder()
            {
                WhereItems = new List<WhereItem>()
                {
                    new WhereItem(){Field = "TaskState",FirstVal = "4", HasFUNC = false, OperationMethod = SqlOperators.OperationMethod.Equal},
                    new WhereItem(){Field = "CreatedTime",FirstVal = "2018-04-01", SecondVal = "2018-04-30",HasFUNC = false, OperationMethod = SqlOperators.OperationMethod.Between}
                }
            });

            return taskservice.GetList(qbList);
          //  return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

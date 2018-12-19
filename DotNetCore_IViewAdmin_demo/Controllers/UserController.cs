using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using App.Services;
using App.Services.Dto;
using YF.Base.Data;
using YF.Utility.Extensions;
using YF.Utility.Message;
using YF.Utility.Secutiry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore_iViewAdmin_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IBaseUsers _service = new BaseUsersService();
        // GET: api/User
        [HttpGet]
        [Route("GetPage")]
        public OperationResult<List<BaseUsersDto>> GetPage(int index)
        {
            OperationResult<List<BaseUsersDto>> result = new OperationResult<List<BaseUsersDto>>(OperationResultType.Success);
            try
            {
                List<QueryBuilder> qbList = new List<QueryBuilder>
                {
                  
                    new QueryBuilder()
                    {
                        WhereItems = new List<WhereItem>(){new WhereItem(){Field = "UserType", FirstVal = "1",HasFUNC = false,OperationMethod = SqlOperators.OperationMethod.Equal}}
                    }
                };
                var total = 0;
                result.Data = _service.GetPageList(qbList, new SortCondition("Id",ListSortDirection.Descending), 10, index, out total);
                result.Total = total;
                if (result.Data != null)
                {
                    result.Message = "获取成功！";
                }
                else
                {
                    result.Message = "没有任何数据！";
                }
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.ResultError(ex.Message);
            }

            return result;

        }


        // GET: api/User/5
        [HttpGet]
        [Route("GetUser")]
        public OperationResult<BaseUsersDto> Get(int id)
        {
            OperationResult<BaseUsersDto> result = new OperationResult<BaseUsersDto>(OperationResultType.Success);

            try
            {
                result.Data = _service.GetDto(id);
                if (result.Data != null)
                {
                    result.Message = "获取成功！";
                }
                else
                {
                    result.ResultError("未找到对应的用户信息！");
                }
            }
            catch (Exception ex)
            {
                result.ResultError(ex.Message);
            }

            return result;
        }

        // POST: api/User
        [HttpPost]
        [Authorize]
        [Route("AddUser")]
        public OperationResult<bool> Post(BaseUsersDto dto)
        {
            OperationResult<bool> result = new OperationResult<bool>(OperationResultType.Success);
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                dto.PassWord = HashHelper.GetMd5("123456");
                dto.UserType = 1;
                dto.CreatedTime = DateTime.Now;
                dto.CreateUser = identity.Name;
                dto.CreateUserId = identity.Claims.Where(a => a.Type == "id").Select(a => a.Value).FirstOrDefault()
                    .ToInt();
                result = _service.Add(dto);
                if (result.Data)
                {
                    result.Message = "添加成功！";
                }
            }
            catch (Exception ex)
            {
                result.ResultError(ex.Message);

            }
            return result;


        }

        // PUT: api/User/5
        [HttpPut]
        [Authorize]
        [Route("UpdateUser")]
        public OperationResult<bool> Put(BaseUsersDto dto)
        {
            OperationResult<bool> result = new OperationResult<bool>(OperationResultType.Success);
            try
            {
                //dto.UpdateTime = DateTime.Now;
                result = _service.Update(dto);

            }
            catch (Exception ex)
            {
                result.ResultError(ex.Message);

            }
            return result;
        }

        
        [HttpDelete]
        [Authorize]
        [Route("DeleteUser")]
        public OperationResult<bool> Delete(string ids)
        {
            OperationResult<bool> result = new OperationResult<bool>(OperationResultType.Success);
            try
            {
                result.Data = _service.Delete(ids);
                if (result.Data)
                {
                    result.Message = "删除成功！";
                }
                else
                {
                    result.ResultError("删除失败！");
                }


            }
            catch (Exception ex)
            {
                result.ResultError(ex.Message);
            }

            return result;
        }

    }
}

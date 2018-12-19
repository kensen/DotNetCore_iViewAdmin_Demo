using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YF.Utility.Message;
using App.Services.Dto;
using  App.Services;
using YF.Base.Data;
using YF.Utility.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DotNetCore_iViewAdmin_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IBaseRole _service = new BaseRoleService();

        // GET: api/Role
        [HttpGet]
        [Route("GetPage")]
        public OperationResult<List<BaseRoleDto>> GetPage(int index)
        {
            OperationResult<List<BaseRoleDto>> result = new OperationResult<List<BaseRoleDto>>(OperationResultType.Success);
            try
            {
                List<QueryBuilder> qbList = new List<QueryBuilder>
                {
                    new QueryBuilder()
                    {
                        WhereItems = new List<WhereItem>(){new WhereItem(){Field = "IsDeleted", FirstVal = "0",HasFUNC = false,OperationMethod = SqlOperators.OperationMethod.Equal}}
                    }
                };
                var total = 0;
                result.Data = _service.GetPageList(qbList, new SortCondition("Id", ListSortDirection.Descending), 10, index, out total);
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
                result.ResultError(ex.Message);
            }
           
            return result;

        }

        [HttpGet]
        [Route("GetAll")]
        public OperationResult<List<BaseRoleDto>> GetAll()
        {
            OperationResult<List<BaseRoleDto>> result = new OperationResult<List<BaseRoleDto>>(OperationResultType.Success);
            try
            {

                result.Data = _service.GetAll();
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
                result.ResultError(ex.Message);
            }

            return result;

        }


        // GET: api/Role/5
        [HttpGet]
        [Route("GetRole")]
        public OperationResult<BaseRoleDto> Get(int id)
        {
            OperationResult<BaseRoleDto> result = new OperationResult<BaseRoleDto>(OperationResultType.Success);

            try
            {
                result.Data = _service.GetDto(id);
                if (result.Data != null)
                {
                    result.Message = "获取成功！";
                }
                else
                {
                    result.ResultError("未找到对应的角色信息！");
                }
            }
            catch (Exception ex)
            {
                result.ResultError(ex.Message);
            }

            return result;
        }

        // POST: api/Role
        [HttpPost]
        [Authorize]
        [Route("AddRole")]
        public OperationResult<bool> Post(BaseRoleDto dto)
        {
            OperationResult<bool> result = new OperationResult<bool>(OperationResultType.Success);
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                dto.CreatedTime = DateTime.Now;
                dto.UpdateTime = DateTime.Now;
                dto.CreateUser = identity.Name;
                dto.CreateUserId = identity.Claims.Where(a => a.Type == "id").Select(a => a.Value).FirstOrDefault()
                    .ToInt();
                result.Data = _service.Add(dto);
                if (result.Data)
                {
                    result.Message = "添加成功！";
                }
                else
                {
                    result.ResultError("添加失败！");
                }
                
            }
            catch (Exception ex)
            {
                result.ResultError(ex.Message);
               
            }
            return result;


        }

        // PUT: api/Role/5
        [HttpPut]
        [Authorize]
        [Route("UpdateRole")]
        public OperationResult<bool> Put(BaseRoleDto dto)
        {
            OperationResult<bool> result = new OperationResult<bool>(OperationResultType.Success);
            try
            {
                dto.UpdateTime = DateTime.Now;
                result.Data = _service.Update(dto);
                if (result.Data)
                {
                    result.Message = "修改成功！";
                }
                else
                {
                    result.ResultError("修改失败！");
                }

            }
            catch (Exception ex)
            {
                result.ResultError(ex.Message);

            }
            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Authorize]
        [Route("DeleteRole")]
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

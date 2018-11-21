//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
//	   生成时间 2018-11-16 15:45:45 by 余庆元
//     对此文件为固定的仓储基类继承，修改可能导致重新生成时被覆盖。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Comba.Base.Data;
using App.Models;
using App.Repositories;
using App.Services.Dto;

namespace App.Services
{	
    	

	 public class TasksService:ITasks
    {
        IConnectionFactory connection = new ConnectionFactory();
        TasksRepository repository;

        public TasksService()
        {
            repository = new TasksRepository(connection);
           // Mapper.CreateMap<Tasks, TasksDto>();
           // Mapper.CreateMap<TasksDto, Tasks>();

			//var cfg = new MapperConfigurationExpression();
			//cfg.CreateMap<Tasks, TasksDto>();
			//cfg.CreateMap<TasksDto, Tasks>();
			//Mapper.Initialize(cfg);
        }

        public bool Add(TasksDto dto)
        {
            Tasks model = Mapper.Map<TasksDto, Tasks>(dto);
            return repository.Insert(model);
        }

        public bool Update(TasksDto dto)
        {
           // throw new NotImplementedException();
          //  Tasks model = Mapper.Map<TasksDto, Tasks>(dto);
            return repository.Update<TasksDto>(dto);
        }

        public bool Delete(Guid id)
        {
            return repository.Delete(id);
        }

        public bool Delete(string ids)
        {
            return repository.Delete(ids);
        }

        public List<TasksDto> GetAll()
        {
          //  AutoMapper.Mapper.CreateMap<Address, AddressDto>();
            var TasksDtoList = Mapper.Map<List<Tasks>, List<TasksDto>>(repository.GetList());
            return TasksDtoList;
        }

        public List<TasksDto> GetList(List<QueryBuilder> qbList)
        {
           // throw new NotImplementedException();
            var TasksDtoList = Mapper.Map<List<Tasks>, List<TasksDto>>(repository.GetList(qbList));
            return TasksDtoList;
        }

        public List<TasksDto> GetPageList(List<QueryBuilder> queryBuliders, SortCondition sort, int intPageSize, int intCurrentIndex, out int total)
        {
           // throw new NotImplementedException();
            
            var TasksDtoList = Mapper.Map<List<Tasks>, List<TasksDto>>(repository.QueryPage(queryBuliders,sort,intPageSize,intCurrentIndex,out total));
            return TasksDtoList;
        }

        public List<TasksDto> GetPageList(string sql, SortCondition sort, int intPageSize, int intCurrentIndex, out int total)
        {
            throw new NotImplementedException();
        }
    }

}

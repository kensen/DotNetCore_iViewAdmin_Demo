//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
//	   生成时间 2018-12-12 16:24:43 by 余庆元
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
using YF.Base.Data;
using App.Models;
using App.Repositories;
using App.Services.Dto;

namespace App.Services
{	
    	

	 public class BaseTokensService:IBaseTokens
    {
        IConnectionFactory connection = new ConnectionFactory();
        BaseTokensRepository repository;

        public BaseTokensService()
        {
            repository = new BaseTokensRepository(connection);
           // Mapper.CreateMap<BaseTokens, BaseTokensDto>();
           // Mapper.CreateMap<BaseTokensDto, BaseTokens>();

			//var cfg = new MapperConfigurationExpression();
			//cfg.CreateMap<BaseTokens, BaseTokensDto>();
			//cfg.CreateMap<BaseTokensDto, BaseTokens>();
			//Mapper.Initialize(cfg);
        }

        public bool Add(BaseTokensDto dto)
        {
            BaseTokens model = Mapper.Map<BaseTokensDto, BaseTokens>(dto);
            return repository.Insert(model);
        }

        public bool Update(BaseTokensDto dto)
        {
           // throw new NotImplementedException();
          //  BaseTokens model = Mapper.Map<BaseTokensDto, BaseTokens>(dto);
            return repository.Update<BaseTokensDto>(dto);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public bool Delete(string ids)
        {
            return repository.Delete(ids);
        }

        public List<BaseTokensDto> GetAll()
        {
          //  AutoMapper.Mapper.CreateMap<Address, AddressDto>();
            var BaseTokensDtoList = Mapper.Map<List<BaseTokens>, List<BaseTokensDto>>(repository.GetList());
            return BaseTokensDtoList;
        }

        public List<BaseTokensDto> GetList(List<QueryBuilder> qbList)
        {
           // throw new NotImplementedException();
            var BaseTokensDtoList = Mapper.Map<List<BaseTokens>, List<BaseTokensDto>>(repository.GetList(qbList));
            return BaseTokensDtoList;
        }

        public List<BaseTokensDto> GetPageList(List<QueryBuilder> queryBuliders, SortCondition sort, int intPageSize, int intCurrentIndex, out int total)
        {
           // throw new NotImplementedException();
            
            var BaseTokensDtoList = Mapper.Map<List<BaseTokens>, List<BaseTokensDto>>(repository.QueryPage(queryBuliders,sort,intPageSize,intCurrentIndex,out total));
            return BaseTokensDtoList;
        }

        public List<BaseTokensDto> GetPageList(string sql, SortCondition sort, int intPageSize, int intCurrentIndex, out int total)
        {
            throw new NotImplementedException();
        }
    }

}

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
using Dapper;
using Comba.Base;
using Comba.Base.Data;
using Comba.Utility.Extensions;
using App.Models;

namespace App.Repositories
{	
    	
	public partial class BaseTokensRepository:RepositoryBase<BaseTokens,int>
    {
		public BaseTokensRepository(IConnectionFactory connectionFactory)
                : base(connectionFactory)
        {               
        }
		
    }

}


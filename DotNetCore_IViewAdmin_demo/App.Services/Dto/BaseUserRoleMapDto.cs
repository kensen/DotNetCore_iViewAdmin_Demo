 
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
//	   生成时间 2018-12-12 16:24:42 by 余庆元
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using YF.Base.Data;
namespace App.Services.Dto
{	
    	
	public class BaseUserRoleMapDto:IAddDto,IEditDto<int>
    {
				/// <summary>
		/// 
		/// </summary>		
		public int Id { get; set; }
	    		/// <summary>
		/// 
		/// </summary>		
		public int? UserId { get; set; }
	    		/// <summary>
		/// 
		/// </summary>		
		public int? RoleId { get; set; }
	    		/// <summary>
		/// 
		/// </summary>		
		public DateTime? CreatedTime { get; set; }
	    		/// <summary>
		/// 
		/// </summary>		
		public bool? IsDeleted { get; set; }
	    	
    }
}
 
 
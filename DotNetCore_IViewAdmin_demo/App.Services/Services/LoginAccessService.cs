using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Repositories;
using App.Services;
using App.Services.Dto;
using YF.Base.Data;

namespace App.Services
{
    public class LoginAccessService : ILoginAccess
    {
        readonly IConnectionFactory _connection = new ConnectionFactory();
        readonly BaseUsersRepository _repository;

        public LoginAccessService()
        {
            _repository = new BaseUsersRepository(_connection);
           
        }

        public bool ChangePwd(string loginId, string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE BaseUsers SET PassWord=@PassWord WHERE LoginId=@LoginId");
            return _repository.Execute(strSql.ToString(), new { PassWord = password, LoginId = loginId}) > -1;

        }

        public UserInfoDto GetDto(int Id)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT * FROM [dbo].[v_UserInfo] WHERE Id=@Id ");
                return _repository.Query<UserInfoDto>(strSql.ToString(), new { Id = Id }).FirstOrDefault();

            }
            catch (Exception e)
            {
                return null;
                //Console.WriteLine(e);
                //throw;
            }
        }

        public UserInfoDto GetDto(string loginId)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT * FROM [dbo].[v_UserInfo] WHERE loginId=@LoginId ");
                return _repository.Query<UserInfoDto>(strSql.ToString(), new { LoginId = loginId }).FirstOrDefault();

            }
            catch (Exception e)
            {
                return null;
                //Console.WriteLine(e);
                //throw;
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserInfoDto Login(string loginId, string password)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT * FROM [dbo].[v_UserInfo] WHERE loginId=@LoginId AND PassWord=@PassWord");
                return _repository.Query<UserInfoDto>(strSql.ToString(), new { LoginId = loginId, PassWord = password }).FirstOrDefault();

            }
            catch (Exception e)
            {
                return null;
                //Console.WriteLine(e);
                //throw;
            }
         
        }
    }
}

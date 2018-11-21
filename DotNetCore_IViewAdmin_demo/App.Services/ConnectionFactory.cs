using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Comba.Base.Data;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.IO;
using Comba.Base;
using Microsoft.Extensions.Configuration;

namespace App.Services
{
    public class ConnectionFactory : IConnectionFactory, IDependency
    {
        private readonly IDbConnection _cnx;
        private readonly MyDb _mydb;
      //  private  IDbTransaction _tsn;

       public ConnectionFactory()
        {
            _cnx = GetSqlConnection();
            //_cnx.Open();
            //_tsn = _cnx.BeginTransaction();
            _mydb = MyDb.Init((DbConnection)_cnx, 2000);
        }

       public ConnectionFactory(string conStr)
       {
           _cnx = GetSqlConnection(conStr);
           //_cnx.Open();
           //_tsn = _cnx.BeginTransaction();
           _mydb = MyDb.Init((DbConnection)_cnx, 2000);
       }

        public IDbConnection GetConnection()
        {
            return _cnx;
        }

        //public IDbTransaction GetTransaction()
        //{
        //    return _tsn;
        //}

        public SqlConnection GetSqlConnection(string conStr="")
        {
            if(string.IsNullOrEmpty(conStr))
            {
                //添加 json 文件路径
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
                //创建配置根对象
                var configurationRoot = builder.Build();
                // conStr = configurationRoot.GetSection("SQLConnection").GetSection("Connecting").Value ;
                conStr = configurationRoot.GetConnectionString("DefaultConnection");
            }
            string cnxStr = conStr;
            // "Data Source=Yu;Initial Catalog=TestDB;Integrated Security=True";
            var cnx = new SqlConnection(cnxStr);
            return cnx;
        }


        public MyDb GetDb()
        {
            return _mydb;
        }
    }
}

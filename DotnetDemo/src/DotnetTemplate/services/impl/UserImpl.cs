using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetdemo.model;

using Dapper;
using MySql;
using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace dotnetdemo.Service
{
    public class UserImpl : IUser
    {
        // https://github.com/StackExchange/Dapper

        IDbConnection MysqlConn;

        private readonly IOptionsSnapshot<AppSetting> _settings;
        public UserImpl(IOptionsSnapshot<AppSetting> settings)
        {
            _settings = settings;
            MysqlConn = new MySqlConnection(_settings.Value.connectionStrings.MySqlDemo);
            MysqlConn.Open();
        }

        public IConfiguration Configuration { get; }
        public UserImpl(IConfiguration configuration)
        {
            Configuration = configuration;
            MysqlConn = new MySqlConnection(Configuration.GetConnectionString("MsSqlDemo"));
            MysqlConn.Open();
        }
       

        public Wapper.OutputT<int> Create(User user)
        {
            var output = new Wapper.OutputT<int>();
            try
            {
                using (MysqlConn)
                {
                    output.code = model.CodeEnum.Success;
                    output.msg = model.CodeEnum.Success.Description();
                    output.data= MysqlConn.Execute(@"insert  into `user`(name, sex) values (@name, @sex)", user);
                }
            }
            catch(Exception ex)
            {
                output.code = model.CodeEnum.Error;
#if DEBUG
                output.msg = ex.ToString();
#else
                output.msg = Model.CodeEnum.Error.Description();
#endif
            }
            return output;
        }



        Wapper.OutputT<int> IUser.Edit(User user)
        {
            var output = new Wapper.OutputT<int>();
            try
            {
                using (MysqlConn)
                {
                    output.code = model.CodeEnum.Success;
                    output.msg = model.CodeEnum.Success.Description();
                    output.data = MysqlConn.Execute(@"update user set name=@name, sex=@sex where userid=@userid", user);
                }
            }
            catch (Exception ex)
            {
                output.code = model.CodeEnum.Error;
#if DEBUG
                output.msg = ex.ToString();
#else
                output.msg = Model.CodeEnum.Error.Description();
#endif
            }
            return output;
        }

        Wapper.OutputT<int> IUser.Delete(int id)
        {
            var output = new Wapper.OutputT<int>();
            try
            {
                using (MysqlConn)
                {
                    output.code = model.CodeEnum.Success;
                    output.msg = model.CodeEnum.Success.Description();
                    output.data = MysqlConn.Execute($"delete from user where userid={id}");
                }
            }
            catch (Exception ex)
            {
                output.code = model.CodeEnum.Error;
#if DEBUG
                output.msg = ex.ToString();
#else
                output.msg = Model.CodeEnum.Error.Description();
#endif
            }
            return output;
        }

        Wapper.OutputT<User> IUser.GetById(int id)
        {
            var output = new Wapper.OutputT<User>();
            try
            {
                using (MysqlConn)
                {
                    output.code = model.CodeEnum.Success;
                    
                    var users = MysqlConn.Query<User>($"select * from  user where userid={id}").ToArray();
                    if (users.Count() > 0)
                    {
                        output.data = users[0];
                        output.msg = model.CodeEnum.Success.Description();
                    }
                    else
                    {
                        output.msg = "no data";
                    }
                }
            }
            catch (Exception ex)
            {
                output.code = model.CodeEnum.Error;
#if DEBUG
                output.msg = ex.ToString();
#else
                output.msg = Model.CodeEnum.Error.Description();
#endif
            }
            return output;
        }

        Wapper.OutputT<IEnumerable<User>> IUser.GetAll()
        {
            var output = new Wapper.OutputT<IEnumerable<User>>();
            try
            {
                using (MysqlConn)
                {
                    output.data = MysqlConn.Query<User>($"SELECT * FROM `user`").ToList();
                    output.code = model.CodeEnum.Success;
                    output.msg = model.CodeEnum.Success.Description();
                }
            }
            catch (Exception ex)
            {
                output.code = model.CodeEnum.Error;
#if DEBUG
                output.msg = ex.ToString();
#else
                output.msg = Model.CodeEnum.Error.Description();
#endif
            }
            return output;
        }
    }
}

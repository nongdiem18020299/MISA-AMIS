using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Interfaces.Validate;
using MySqlConnector;

namespace MISA.Core.Validate
{
    public class BaseValidate<Entity>:IBaseValidate<Entity>
    {
        protected IDbConnection DbConnection;
        DynamicParameters _parameters = new DynamicParameters();
        readonly IConfiguration _configuration;
        public BaseValidate(IConfiguration configuration)
        {
            _configuration = configuration;
            DbConnection = new MySqlConnection(_configuration.GetConnectionString("MISA-AMISConnectionString"));
        }

        /// <summary>
        /// Kiểm tra mã nhân viên có bị trùng hay không
        /// </summary>
        /// <param name="employee">employee</param>
        /// <returns>True: Mã nhân viên bị trùng; False: Mã nhân viên không bị trùng</returns>
        /// CreateBy: NTDIEM(16/08/2021)
        public bool CheckCodeDublicate(Entity entity)
        {
            var className = typeof(Entity).Name;
            var tableName = className;
            //var field = entity.GetType()
            if (className == "Position")
            {
                tableName = $"{className}s";
            }
            var entityCode = entity.GetType().GetProperty($"{className}Code").GetValue(entity, null);
            var sqlCommnad = $"IF EXISTS (SELECT {className}Code FROM {tableName} e WHERE {className}Code = '{entityCode}' LIMIT 1) THEN SELECT TRUE;ELSE SELECT FALSE;END IF; ";
            var res = DbConnection.QueryFirstOrDefault<bool>(sqlCommnad);
            return res;
        }

        /// <summary>
        /// Hàm kiểm tra mã nhân viên bị trùng khi sửa nhân viên
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <param name="employeeId"></param>
        /// <returns>true: Nếu mã nhân viên trùng: false; nếu mã nhân viên chưa tồn tại</returns>
        /// CreateBy: NTDIEM(16/08/2021)
        public bool CheckDublicateCodePut(string entityCode, Guid entityId)
        {
            var className = typeof(Entity).Name;
            var tableName = className;
            if (className == "Position")
            {
                tableName = $"{className}s";
            }
            var sqlCommand = $"SELECT {className}Id FROM {tableName} WHERE {className}Code = '{entityCode}' LIMIT 1";

            var res = DbConnection.QueryFirstOrDefault<Guid>(sqlCommand);
            if (res == entityId || res == Guid.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

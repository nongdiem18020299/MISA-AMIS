using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infranstructure;

namespace MISA.Infractructure.Repository
{
    public class EmployeeRepository: BaseRepository<Employee>, IEmployeeRepository
    {
        #region Constructure
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {

        }
        #endregion
        #region Method
        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// CreateBy: NTDIEM (16/08/2021)
        public string GetNewEmployeeCode()
        {
            var res = DbConnection.QueryFirstOrDefault<string>("Proc_GetNewEmployeeCode", commandType: CommandType.StoredProcedure);
            return res;
        }
        /// <summary>
        /// Lọc nhân viên
        /// </summary>
        /// <param name="employeeFilter">Từ khóa lọc</param>
        /// <param name="pageIndex">Số trang</param>
        /// <param name="pageSize">Cỡ trang</param>
        /// <returns>danh sách nhân viên sau khi lọc</returns>
        /// CreateBy: NTDIEM(18/08/2021)
        public object GetEmployeeFilterPaging(string employeeFilter,int pageIndex, int pageSize)
        {
            var totalRecord = 0;
            var totalPage = 0;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeFilter", employeeFilter);
            parameters.Add("@PageIndex", pageIndex);
            parameters.Add("@PageSize", pageSize);
            parameters.Add("@TotalRecord", totalRecord, DbType.Int32, ParameterDirection.Output);
            parameters.Add("@TotalPage", totalPage, DbType.Int32, ParameterDirection.Output);
            var res = DbConnection.Query<Employee>("Proc_GetEmployeesFilterPaging", parameters, commandType: CommandType.StoredProcedure);
            totalPage = parameters.Get<int>("@TotalPage");
            totalRecord = parameters.Get<int>("@TotalRecord");
            var result = new
            {
                Data = res,
                TotalPage = totalPage,
                TotalRecord = totalRecord
            };
            return result;
        }
        #endregion
    }
}

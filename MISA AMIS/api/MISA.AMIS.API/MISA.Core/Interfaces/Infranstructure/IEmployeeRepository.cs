using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities;

namespace MISA.Core.Interfaces.Infranstructure
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// CreateBy: NTDIEM (16/08/2021)
        string GetNewEmployeeCode();

        /// <summary>
        /// Lọc và phân trang
        /// </summary>
        /// <param name="employeeFilter">Tiền tố mã nhân viên</param>
        /// <param name="pageIndex">Sô trang</param>
        /// <param name="pageSize">Cỡ trang</param>
        /// <returns>Dữ liệu sau khi lọc và phân trang</returns>
        /// CreateBy: NTDIEM (16/08/2021)
        object GetEmployeeFilterPaging(string employeeFilter, int pageIndex, int pageSize);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infranstructure;
using MISA.Core.Interfaces.Service;

namespace MISA.AMIS.API.Controllers
{
    [Route("api/v1/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Field
        IEmployeeService _employeeService;
        IEmployeeRepository _employeeRepo;
        #endregion
        #region Constructure
        public EmployeeController(IEmployeeService employeeService, IEmployeeRepository employeeRepo)
        {
            _employeeService = employeeService;
            _employeeRepo = employeeRepo;
        }
        #endregion
        #region GET
        /// <summary>
        /// Lấy toàn bộ dữ liệu Employee
        /// </summary>
        /// <returns>Dữ liệu từ bảng Employee</returns>
        /// CreateBy:NTDIEM(16/08/2021)
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var employees = _employeeRepo.GetAll();
                return employees.Count() > 0 ? Ok(employees) : NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, _employeeService.ErrorException(e));
            }

        }

        /// <summary>
        /// Lấy dữ liệu  theo id
        /// Create: NTDIEM(23/07/2021)
        /// </summary>
        /// <param name="id">employeeId</param>
        /// <returns>Dữ liệu lấy được theo id nhân viên</returns>
        /// CreateBy:NTDIEM(16/08/2021)
        [HttpGet("{id}")]
        public IActionResult GetId(Guid id)
        {
            try
            {
                var employee = _employeeRepo.GetById(id);
                return employee != null ? Ok(employee) : NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(500, _employeeService.ErrorException(e));
            }
        }

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// CreateBy: NTDIEM (16/08/2021)
        [HttpGet("NewEmployeeCode")]
        public IActionResult GetNewEmployeeCode()
        {
            try
            {
                var newEmployeeCode = _employeeRepo.GetNewEmployeeCode();
                return newEmployeeCode != null ? Ok(newEmployeeCode) : NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, _employeeService.ErrorException(e));
            }
        }

        /// <summary>
        /// Lọc dữ liệu Employee và phân trang
        /// </summary>
        /// <param name="employeeFilter">Mã nhân viên</param>
        /// <param name="departmentId">Mã phòng ban</param>
        /// <param name="positionId">Mã vị trí</param>
        /// <param name="pageIndex">Số trang</param>
        /// <param name="pageSize">Kích cỡ trang</param>
        /// <returns></returns>
        [HttpGet("EmployeeFilter")]
        public IActionResult GetEmployeeFilterPaging(string employeeFilter, int pageIndex, int pageSize)
        {
            try
            {
                var res = _employeeRepo.GetEmployeeFilterPaging(employeeFilter, pageIndex, pageSize);
                return res != null ? Ok(res) : NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, _employeeService.ErrorException(e));
            }
        }
        #endregion

        #region POST
        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="employee">Nhân viên</param>
        /// <returns>trạng thái thêm mới</returns>
        /// CreateBy:NTDIEM(16/08/2021)
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            try
            {
                //Validate dữ liệu
                var employeeResult = new ServiceResult();
                employeeResult = _employeeService.Add(employee);
                //Kiểm tra dữ liệu có bị bỏ trống không
                return employeeResult.Success? StatusCode(201, employeeResult) : StatusCode(200, employeeResult);

            }
            catch (Exception e)
            {
                return StatusCode(500, _employeeService.ErrorException(e));
            }
        }
        #endregion

        #region PUT
        /// <summary>
        /// Hàm sửa dữ liệu
        /// </summary>
        /// <param name="id">ID nhân viên</param>
        /// <param name="employee">thông tin nhân viên</param>
        /// <returns>Trạng thái sửa thông tin nhân viên</returns>
        /// CreateBy:NTDIEM(16/08/2021)
        [HttpPut("{id}")]

        public IActionResult Put(Guid id, [FromBody] Employee employee)
        {
            try
            {
                //Validate dữ liệu
                var employeeResult = new ServiceResult();
                employeeResult = _employeeService.Put(employee, id);
                return employeeResult.Success? StatusCode(201, employeeResult) : StatusCode(200, employeeResult);
            }
            catch (Exception e)
            {
                return StatusCode(500, _employeeService.ErrorException(e));
            }

        }
        #endregion

        #region DELETE
        /// <summary>
        /// Xóa nhân viên theo id
        /// </summary>
        /// <param name="id">employeeId</param>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>Trạng thái xóa dữ liệu</returns>
        /// CreateBy:NTDIEM(16/08/2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //Validate dữ liệu
                var employeeResult = new ServiceResult();

                employeeResult = _employeeService.Delete(id);
                return employeeResult.Success ? StatusCode(200, employeeResult) : StatusCode(204, employeeResult);

            }
            catch (Exception e)
            {
                return StatusCode(500, _employeeService.ErrorException(e));
            }

        }
        #endregion
    }
}

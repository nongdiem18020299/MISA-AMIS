using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces.Infranstructure;
using MISA.Core.Interfaces.Service;

namespace MISA.AMIS.API.Controllers
{

    [Route("api/v1/Department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        #region Field
        IDepartmentService _departmentService;
        IDepartmentRepository _departmentRepo;
        #endregion

        #region Constructor
        public DepartmentController(IDepartmentService departmentService, IDepartmentRepository departmentRepository)
        {
            _departmentService = departmentService;
            _departmentRepo = departmentRepository;
        }
        #endregion
        #region Method
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var departments = _departmentRepo.GetAll();
                return departments.Count() > 0 ? Ok(departments) : NoContent();
            }
            catch(Exception e)
            {
                return StatusCode(500, _departmentService.ErrorException(e));
            }
        }
        #endregion
    }
}

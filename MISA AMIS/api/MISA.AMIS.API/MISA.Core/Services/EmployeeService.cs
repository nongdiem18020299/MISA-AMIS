using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infranstructure;
using MISA.Core.Interfaces.Service;
using MISA.Core.Interfaces.Validate;

namespace MISA.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        IEmployeeRepository _emmployeRepo;
        IBaseRepository<Employee> _baseRepo;
        IBaseValidate<Employee> _baseValidate;
        #region Constructor
        public EmployeeService(IEmployeeRepository emmployeRepo, IBaseRepository<Employee> baseRepo, IBaseValidate<Employee> baseValidate) : base(baseValidate, baseRepo)
        {
            ServiceResult = new ServiceResult();
            _emmployeRepo = emmployeRepo;
            _baseRepo = baseRepo;
            _baseValidate = baseValidate;
        }
        #endregion
        #region Method
        #endregion
    }
}

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
    public class DepartmentService:BaseService<Department>, IDepartmentService
    {
        IDepartmentRepository _departmentRepo;
        IBaseRepository<Department> _baseRepo;
        IBaseValidate<Department> _baseValidate;
        #region Constructor
        public DepartmentService(IDepartmentRepository departmentRepo, IBaseRepository<Department> baseRepo, IBaseValidate<Department> baseValidate) : base(baseValidate, baseRepo)
        {
            ServiceResult = new ServiceResult();
            _departmentRepo = departmentRepo;
            _baseRepo = baseRepo;
            _baseValidate = baseValidate;
        }
        #endregion
    }
}

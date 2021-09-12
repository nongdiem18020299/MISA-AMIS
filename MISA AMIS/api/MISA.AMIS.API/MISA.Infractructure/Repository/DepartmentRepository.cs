using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infranstructure;

namespace MISA.Infractructure.Repository
{
    public class DepartmentRepository: BaseRepository<Department>, IDepartmentRepository
    {
        #region Constructure
        public DepartmentRepository(IConfiguration configuration) : base(configuration)
        {

        }
        #endregion
    }
}

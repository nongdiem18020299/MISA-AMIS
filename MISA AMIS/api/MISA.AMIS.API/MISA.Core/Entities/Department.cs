using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Department
    {
       public Guid? DepartmentId { get; set; }
       public string DepartmentName { get; set; }
       public string Description { get; set; }
    }
}

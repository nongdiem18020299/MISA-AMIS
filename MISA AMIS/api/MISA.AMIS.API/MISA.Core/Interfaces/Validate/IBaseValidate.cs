using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Validate
{
    public interface IBaseValidate<Entity>
    {
        bool CheckCodeDublicate(Entity entity);
        bool CheckDublicateCodePut(string entityCode, Guid entityId);
    }
}

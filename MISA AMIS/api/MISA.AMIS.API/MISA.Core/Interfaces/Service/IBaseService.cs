using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities;

namespace MISA.Core.Interfaces.Service
{
    public interface IBaseService<Entity>
    {
        ServiceResult Add(Entity entity);
        ServiceResult Put(Entity entity, Guid id);
        ServiceResult Delete(Guid id);
        ServiceResult ErrorException(Exception e);
    }
}

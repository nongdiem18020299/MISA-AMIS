using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired : Attribute { }

    public class MISAEmail : Attribute { }

    public class MISAPhoneNumber : Attribute { }
}

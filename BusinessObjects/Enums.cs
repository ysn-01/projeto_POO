using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TreatProblems;
using Validations;

namespace BusinessObjects
{
    /// <summary>
    /// Enum para definir os diferentes níveis de permissões.
    /// </summary>
    public enum PERMS
    {
        USER = 0,
        MANAGER = 1,
        ADMIN = 2 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.Models.Repositerie
{
    interface ICompanyRepositery<TEntity>
    {
        TEntity Get(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_History
{
    public interface IRepoCompany
    {
        IRepo<T> CreateRepo<T>() where T : BaseEntity;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_History
{
    internal class RepoCompany : IRepoCompany
    {
        public IRepo<T> CreateRepo<T>() where T : BaseEntity
        {
            return new GenericRepo<T>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_History
{
    public class GenericRepo<T> : IRepo<T> where T : BaseEntity
    {
        private readonly IList<T> _list;
        public GenericRepo()
        {
            this._list = new List<T>();
        }
        public void Add(T entity)
        {
            this._list.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                this._list.Add(entity);
            }
        }

        public void Delete(int id)
        {
            var entity= this._list.FirstOrDefault(x=>x.id==id);
            if (entity!=null)
            {
                this._list.Remove(entity);
            }
        }

        public T Get(int id)
        {
            return this._list.FirstOrDefault(x=>x.id==id);
        }

        public List<T> GetAll()
        {
            return this._list.ToList();
        }

        public void Update(T entity)
        {
            int i = this._list.IndexOf(entity);
            this._list.RemoveAt(i);
            this._list.Add(entity);
        }
    }
}

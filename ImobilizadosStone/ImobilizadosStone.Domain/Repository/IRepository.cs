using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ImobilizadosStone.Domain.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(string id);
        void Insert(T entity);
        void Update(string id, T entity);
        void Delete(string id);

        IEnumerable<T> GetByExpression(Expression<Func<T, bool>> expression);
    }
}

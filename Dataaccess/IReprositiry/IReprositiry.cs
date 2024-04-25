using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.IReprositiry
{
    public interface IReprositiry<R> where R : class
    {
        IEnumerable<R> GetAll();
        R Add(R entity);
        R Update(R entity);
        R Remove(R entity);
        R FindFirstOrDefault(Expression<Func<R, bool>> filter);
        IEnumerable<R> getList(Expression<Func<R, bool>> filter);
        IEnumerable<R> GetPage(Expression<Func<R, bool>> filter, int pageNumber, int pageSize, Expression<Func<R, object>> orderBy);
    }
}

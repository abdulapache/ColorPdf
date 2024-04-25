using Dataaccess.Entites;
using Dataaccess.IReprositiry;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.Reprository
{
    public class Reprository<R> : IReprositiry<R> where R : class
    {
        private readonly RestaurantContext dbContext;
        internal DbSet<R> dbSet;
        public Reprository(RestaurantContext context)
        {
            dbContext = context;
            dbSet = dbContext.Set<R>();
        }
        public R Add(R entity)
        {
            dbSet.Add(entity);
            return entity;
        }
        public IEnumerable<R> getList(Expression<Func<R, bool>> filter)
        {
            IQueryable<R> query = dbSet;
            return query.Where(filter).ToList();
        }

        public IEnumerable<R> GetAll()
        {
            IQueryable<R> query = dbSet;
            return query.ToList();
        }

        public R FindFirstOrDefault(Expression<Func<R, bool>> filter)
        {
            IQueryable<R> query = dbSet;
            return query.Where(filter).FirstOrDefault();
        }

        public R Remove(R entity)
        {
            dbSet.Remove(entity);

            return entity;
        }

        public R Update(R entity)
        {
            dbContext.Update(entity);
            return entity;
        }
        public IEnumerable<R> GetPage(Expression<Func<R, bool>> filter, int pageNumber, int pageSize, Expression<Func<R, object>> orderBy)
        {
            return dbContext.Set<R>().Where(filter).OrderByDescending(orderBy)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSpace.Entities
{
    public class BaseEntity<T> : IRequireContext
    {
        public void SetContext(ExecutionContext context)
        {
            
        }
    }

    public class EntityCollection<T> where T:class,new()
    {
        EntityContext dbContext = null;
        public async Task<IEnumerable<T>> All()
        {
            DbSet<T> set= dbContext.Set<T>();
            return await set.ToListAsync<T>();
        }

        public async Task<T> GetById(int id)
        {
            DbSet<T> set = dbContext.Set<T>();
            return await set.FindAsync(id);
        }

        public void Add(T obj)
        {
            DbSet<T> set = dbContext.Set<T>();
            set.Add(obj);
        }

        public void Update(T obj)
        {
            DbSet<T> set = dbContext.Set<T>();
            set.Attach(obj);
            dbContext.Entry(obj).State = EntityState.Modified;
        }
    }
}

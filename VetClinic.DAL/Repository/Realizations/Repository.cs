using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DAL.Repository.Interfaces;

namespace VetClinic.DAL.Repository.Realizations
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        public Repository(AppDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
            table = this.databaseContext.Set<T>();
        }

        protected readonly AppDatabaseContext databaseContext;

        protected readonly DbSet<T> table;
        public virtual async Task<IEnumerable<T>> GetAllAsync() => await table.ToListAsync();

        public abstract Task<T> GetByIdAsync(string id);
        public virtual async Task InsertAsync(T entity) => await table.AddAsync(entity);

        public virtual async Task UpdateAsync(T entity) =>
            await Task.Run(() => table.Update(entity));

        public virtual async Task DeleteAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            await Task.Run(() => table.Remove(entity));
        }
    }
}

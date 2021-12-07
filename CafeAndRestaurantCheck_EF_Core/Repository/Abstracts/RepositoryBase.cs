using CafeAndRestaurantCheck_EF_Core.Data;
using CafeAndRestaurantCheck_EF_Core.Models.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeAndRestaurantCheck_EF_Core.Repository.Abstracts
{
    public abstract class RepositoryBase<T, TId> : IRepository<T, TId>
        where T : BaseEntity, new()
    {



        protected CafeContext _context;
        public DbSet<T> Table { get; protected set; } //aslinda bu tablom

        protected RepositoryBase()
        {
            _context = new CafeContext();
            Table = _context.Set<T>();
        }
        public virtual T GetById(TId id)
        {
            return Table.Find(id);
        }
        public virtual IQueryable<T> Get(Func<T, bool> predicate = null)
        {
            return predicate == null ? Table : Table.Where(predicate).AsQueryable();
        }
        public virtual IQueryable<T> Get(string[] includes, Func<T, bool> predicate = null) //asiri Yükleme.
        {
            IQueryable<T> query = Table;
            foreach (var include in includes)
            {
                query = Table.Include(include);
            }
            return predicate == null ? query : query.Where(predicate).AsQueryable();
        }


        public virtual void Add(T entity, bool isSaveLater = false)
        {
            Table.Add(entity);
            if (!isSaveLater)
                this.Save();

        }

        public virtual void Remove(T entity, bool isSaveLater = false)
        {
            Table.Remove(entity);
            if (!isSaveLater)
                this.Save();
        }



        public virtual void Update(T entity, bool isSaveLater = false)
        {
            Table.Update(entity);
            if (!isSaveLater)
                this.Save();
        }
        public virtual int Save()
        {
            return _context.SaveChanges();
        }
    }
}
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CollegeAPI.Contracts;
using CollegeAPI.Data.DBConnection;

namespace CollegeAPI.Repository.Common
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationContext _context;
        public RepositoryBase(ApplicationContext context)
        {
             _context = context;
        }

        public virtual  void Create(T entity)
        {
             _context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }        

        public virtual T FInd(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual IQueryable<T> FIndAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public virtual IQueryable<T> FIndByConditon(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsQueryable();
        }
        
        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void Save(){

            _context.SaveChanges();
        }
    }
}
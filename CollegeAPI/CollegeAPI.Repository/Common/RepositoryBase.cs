using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CollegeAPI.Contracts;
using CollegeAPI.Data.DBConnection;
using CollegeAPI.Data.Models;


namespace CollegeAPI.Repository.Common
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class,IActivityLog
    {
        
        protected ApplicationContext _context;
       
        public RepositoryBase(ApplicationContext context)
        {
            this._context = context;               
        }

        public virtual  void Create(T entity)
        {                  
           SetCreateAuditLog(entity);
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
            return _context.Set<T>().AsQueryable().Where(x=> x.IsActive == 1);
        }

        public virtual IQueryable<T> FIndByConditon(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsQueryable();
        }
        
        public virtual void Update(T entity)
        {
            SetUpdateAuditLog(entity);
            _context.Set<T>().Update(entity);
        }
        public void Save(){             
            _context.SaveChanges();
        }
        private void SetCreateAuditLog(T entity){
            entity.IsActive = 1;
            entity.CreatedBy = 1;
            entity.CreatedDate = DateTime.Now;
        }
        private void SetUpdateAuditLog(T entity){
            entity.IsActive = 1;
            entity.UpdatedBy = 1;
            entity.updatedDate = DateTime.Now;
        }
    }
}
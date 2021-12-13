using System.Linq.Expressions;
using System;
using System.Linq;
namespace CollegeAPI.Contracts
{
    public interface IRepositoryBase<T> 
    {
            T  FInd(int id);  
           IQueryable<T>  FIndAll();     
           IQueryable<T>  FIndByConditon(Expression<Func<T,bool>> expression);  
           void Create(T entity);
           void Update(T entity);
           void Delete(T entity); 
           void Save();          
    }
}
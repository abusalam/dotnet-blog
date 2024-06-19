using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace MyWebAPI8.DAL.IRepository
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition);
        Task<ICollection<T>> GetAllByConditionAsync(Expression<Func<T, bool>> condition);

        IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsync();

        T GetSingle(Expression<Func<T, bool>> condition);

        Task<T> GetSingleAysnc(Expression<Func<T, bool>> condition);

        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);

        void SaveChangesManaged();
        IExecutionStrategy GetExecutionStrategy();
         public IQueryable<T> GetAllByLikeCondition(Expression<Func<T, string>> propertySelector, string value);
        public Task<ICollection<T>> GetAllByLikeConditionAsync(Expression<Func<T, string>> propertySelector, string value);
        public List<T> GetMultiple(Expression<Func<T, bool>> condition);
        public Task<List<T>> GetMultipleAsync(Expression<Func<T, bool>> condition);
    }
}
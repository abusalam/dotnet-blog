using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyWebAPI8.DAL.IRepository;

namespace MyWebAPI8.DAL.Repository
{
    public abstract class Repository<T, Tcontext> : IRepository<T> where T : class where Tcontext : DbContext
    {
        protected readonly Tcontext UserDBContext = null;

        public Repository(Tcontext context)
        {
            this.UserDBContext = context;
        }


        public bool IsTransactionRunning()
        {
            return this.UserDBContext.Database.CurrentTransaction == null ? false : true;
        }
        private IDbContextTransaction BeginTran()
        {
            return this.UserDBContext.Database.BeginTransaction();
        }



        public IExecutionStrategy GetExecutionStrategy()
        {
            return this.UserDBContext.Database.CreateExecutionStrategy();
        }


        public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> result = this.UserDBContext.Set<T>();
            if (condition != null)
            {
                result = result.Where(condition);
            }

            return result;
        }

        public async Task<ICollection<T>> GetAllByConditionAsync(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> result = this.UserDBContext.Set<T>();
            if (condition != null)
            {
                result = result.Where(condition);
            }

            return await result.ToListAsync();
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> result = this.UserDBContext.Set<T>();
            return result;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            IQueryable<T> result = this.UserDBContext.Set<T>();
            return await result.ToListAsync();
        }

        public T GetSingle(Expression<Func<T, bool>> condition)
        {
            return this.UserDBContext.Set<T>().Where(condition).FirstOrDefault();
        }
        public async Task<T> GetSingleAysnc(Expression<Func<T, bool>> condition)
        {
            var retValue = await this.UserDBContext.Set<T>().Where(condition).SingleOrDefaultAsync();

            return retValue;
        }
        public List<T> GetMultiple(Expression<Func<T, bool>> condition)
        {
            return this.UserDBContext.Set<T>().Where(condition).ToList();
        }
        public async Task<List<T>> GetMultipleAsync(Expression<Func<T, bool>> condition)
        {
            var result = await this.UserDBContext.Set<T>().Where(condition).ToListAsync();
            return result;
        }

        public IQueryable<T> GetAllByLikeCondition(Expression<Func<T, string>> propertySelector, string value)
        {
            return this.UserDBContext.Set<T>()
                .Where(entity => EF.Functions.Like(EF.Property<string>(entity, GetPropertyName(propertySelector)), $"%{value}%"));
        }

        public async Task<ICollection<T>> GetAllByLikeConditionAsync(Expression<Func<T, string>> propertySelector, string value)
        {
            return await this.UserDBContext.Set<T>()
                .Where(entity => EF.Functions.Like(EF.Property<string>(entity, GetPropertyName(propertySelector)), $"%{value}%"))
                .ToListAsync();
        }

        private string GetPropertyName(Expression<Func<T, string>> propertySelector)
        {
            if (propertySelector.Body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }
            else if (propertySelector.Body is UnaryExpression unaryExpression && unaryExpression.Operand is MemberExpression operand)
            {
                return operand.Member.Name;
            }

            throw new ArgumentException("Invalid property selector");
        }

        public bool Add(T entity)
        {
            this.UserDBContext.Set<T>().Add(entity);
            return true;
        }

        public bool Update(T entity)
        {
            this.UserDBContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public bool Delete(T entity)
        {
            this.UserDBContext.Set<T>().Remove(entity);
            return true;
        }


        public void SaveChangesManaged()
        {
            this.UserDBContext.SaveChanges();
        }
    }
}
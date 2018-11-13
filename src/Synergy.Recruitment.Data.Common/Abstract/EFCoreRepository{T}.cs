using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Synergy.Recruitment.Data.Models.Abstract;

namespace Synergy.Recruitment.Data.Common.Abstract
{
    /// <summary>
    /// Provides implementations of generic EntityFrameworkCore repository.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    /// <seealso cref="Synergy.Recruitment.Data.Common.Abstract.IRelationalRepository{T}" />
    /// <seealso cref="Synergy.Recruitment.Data.Common.Abstract.IRepository{T}" />
    /// <seealso cref="BaseEntity" />
    public abstract class EFCoreRepository<T> : IRelationalRepository<T>
        where T : BaseEntity
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EFCoreRepository{T}"/> class.
        /// </summary>
        protected EFCoreRepository(DbContext context)
        {
            Context = context;
            Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        #endregion

        public IQueryable<T> Queryable => Set.AsNoTracking();

        private DbSet<T> Set => Context.Set<T>();

        private DbContext Context { get; }

        #region Public Methods

        public void Add(T item) => Set.Add(item);

        public async Task AddAsync(T item)
        {
            await Set.AddAsync(item).ConfigureAwait(false);

            await Context.SaveChangesAsync();
        }

        public void AddRange(IEnumerable<T> list) => Set.AddRange(list);

        public async Task AddRangeAsync(IEnumerable<T> list)
        {
            await Set.AddRangeAsync(list).ConfigureAwait(false);

            await Context.SaveChangesAsync();
        }

        public bool Any() => Set.Any();

        public bool Any(Expression<Func<T, bool>> where) => Set.Any(where);

        public Task<bool> AnyAsync() => Set.AnyAsync();

        public Task<bool> AnyAsync(Expression<Func<T, bool>> where) => Set.AnyAsync(where);

        public long Count() => Set.LongCount();

        public long Count(Expression<Func<T, bool>> where) => Set.LongCount(where);

        public Task<long> CountAsync() => Set.LongCountAsync();

        public Task<long> CountAsync(Expression<Func<T, bool>> where) => Set.LongCountAsync(where);

        public void Delete(object key) => Set.Remove(Select(key));

        public void Delete(Expression<Func<T, bool>> where) => Set.RemoveRange(List(where));

        public async Task DeleteAsync(object key)
        {
            Delete(key);

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> where)
        {
            Delete(where);

            await Task.CompletedTask;
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where)
            => QueryableWhere(where).FirstOrDefault();

        public T FirstOrDefault(params Expression<Func<T, object>>[] include)
            => QueryableInclude(include).FirstOrDefault();

        public T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).FirstOrDefault();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).FirstOrDefaultAsync();
        }

        public Task<T> FirstOrDefaultAsync(params Expression<Func<T, object>>[] include)
        {
            return QueryableInclude(include).FirstOrDefaultAsync();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).FirstOrDefaultAsync();
        }

        public TEntityResult FirstOrDefaultResult<TEntityResult>(Expression<Func<T, bool>> where, Expression<Func<T, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).FirstOrDefault();
        }

        public Task<TEntityResult> FirstOrDefaultResultAsync<TEntityResult>(Expression<Func<T, bool>> where, Expression<Func<T, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).FirstOrDefaultAsync();
        }

        public T LastOrDefault(params Expression<Func<T, object>>[] include)
        {
            return QueryableInclude(include).LastOrDefault();
        }

        public T LastOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).LastOrDefault();
        }

        public Task<T> LastOrDefaultAsync(params Expression<Func<T, object>>[] include)
        {
            return QueryableInclude(include).LastOrDefaultAsync();
        }

        public Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).LastOrDefaultAsync();
        }

        public TEntityResult LastOrDefaultResult<TEntityResult>(Expression<Func<T, bool>> where, Expression<Func<T, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).LastOrDefault();
        }

        public Task<TEntityResult> LastOrDefaultResultAsync<TEntityResult>(Expression<Func<T, bool>> where, Expression<Func<T, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).LastOrDefaultAsync();
        }

        public IEnumerable<T> List()
        {
            return Set.ToList();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).ToList();
        }

        public IEnumerable<T> List(params Expression<Func<T, object>>[] include)
        {
            return QueryableInclude(include).ToList();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).ToList();
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await Set.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where)
        {
            return await QueryableWhere(where).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> ListAsync(params Expression<Func<T, object>>[] include)
        {
            return await QueryableInclude(include).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return await QueryableWhereInclude(where, include).ToListAsync().ConfigureAwait(false);
        }

        public T Select(object key)
        {
            return Set.Find(key);
        }

        public Task<T> SelectAsync(object key)
        {
            return Set.FindAsync(key);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).SingleOrDefault();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).SingleOrDefault();
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return QueryableWhere(where).SingleOrDefaultAsync();
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return QueryableWhereInclude(where, include).SingleOrDefaultAsync();
        }

        public TEntityResult SingleOrDefaultResult<TEntityResult>(Expression<Func<T, bool>> where, Expression<Func<T, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).SingleOrDefault();
        }

        public Task<TEntityResult> SingleOrDefaultResultAsync<TEntityResult>(Expression<Func<T, bool>> where, Expression<Func<T, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).SingleOrDefaultAsync();
        }

        public void Update(T item, object key)
        {
            Context.Entry(Select(key)).CurrentValues.SetValues(item);
        }

        public async Task UpdateAsync(T item, object key)
        {
            Update(item, key);

            await Task.CompletedTask;
        }

        // public Task UpdateAsync(T item, object key) => UpdateAsync(item, key);

        public async Task<IEnumerable<TEntityResult>> ListAsync<TEntityResult>(Expression<Func<T, TEntityResult>> select)
            => await QueryableSelect(select).ToListAsync();

        public async Task<IEnumerable<TEntityResult>> ListAsync<TEntityResult>(
            Expression<Func<T, bool>> whereExpression,
            Expression<Func<T, TEntityResult>> selectExpression)
                => await QueryableWhereSelect(whereExpression, selectExpression).ToListAsync();

        public Task<TEntityResult> SelectFirstOrDefaultAsync<TEntityResult>(
            Expression<Func<T, TEntityResult>> selectExpression,
            Expression<Func<TEntityResult, bool>> fodExpression)
            => QueryableSelect(selectExpression).FirstOrDefaultAsync(fodExpression);

        #endregion

        #region Private Methods

        private IQueryable<TEntityResult> QueryableSelect<TEntityResult>(Expression<Func<T, TEntityResult>> select)
            => Queryable.Select(select);

        private static IQueryable<T> Include(IQueryable<T> queryable, Expression<Func<T, object>>[] properties)
        {
            properties?.ToList().ForEach(property => queryable = queryable.Include(property));

            return queryable;
        }

        private IQueryable<T> QueryableInclude(Expression<Func<T, object>>[] include)
        {
            return Include(Queryable, include);
        }

        private IQueryable<T> QueryableWhere(Expression<Func<T, bool>> where)
        {
            return Queryable.Where(where);
        }

        private T QueryableFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Queryable.FirstOrDefault(predicate);
        }

        private IQueryable<T> QueryableWhereInclude(Expression<Func<T, bool>> where, Expression<Func<T, object>>[] include)
        {
            return Include(QueryableWhere(where), include);
        }

        private IQueryable<TEntityResult> QueryableWhereSelect<TEntityResult>(Expression<Func<T, bool>> where, Expression<Func<T, TEntityResult>> select)
        {
            return QueryableWhere(where).Select(select);
        }

        #endregion
    }
}

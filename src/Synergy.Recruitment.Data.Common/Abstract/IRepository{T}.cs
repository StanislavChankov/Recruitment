﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Synergy.Recruitment.Data.Common.Abstract
{
    /// <summary>
    /// Provides abstract behaviors for repository.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        void Add(T item);

        Task AddAsync(T item);

        void AddRange(IEnumerable<T> list);

        Task AddRangeAsync(IEnumerable<T> list);

        bool Any();

        bool Any(Expression<Func<T, bool>> where);

        Task<bool> AnyAsync();

        Task<bool> AnyAsync(Expression<Func<T, bool>> where);

        long Count();

        long Count(Expression<Func<T, bool>> where);

        Task<long> CountAsync();

        Task<long> CountAsync(Expression<Func<T, bool>> where);

        void Delete(object key);

        void Delete(Expression<Func<T, bool>> where);

        Task DeleteAsync(object key);

        Task DeleteAsync(Expression<Func<T, bool>> where);

        T FirstOrDefault(Expression<Func<T, bool>> where);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where);

        IEnumerable<T> List();

        IEnumerable<T> List(Expression<Func<T, bool>> where);

        Task<IEnumerable<T>> ListAsync();

        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where);

        T Select(object key);

        Task<T> SelectAsync(object key);

        T SingleOrDefault(Expression<Func<T, bool>> where);

        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where);

        void Update(T item, object key);

        Task UpdateAsync(T item, object key);
    }
}

﻿using api_cinema_challenge.Data;
using api_cinema_challenge.Exceptions;
using LinqKit;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api_cinema_challenge.Repository
{
    public class Repository<T, U> : IRepository<T, U>
        where T : class
        where U : struct
    {
        private DataContext _db;
        private DbSet<T> _table = null!;
        public Repository(DataContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            await _table.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRange(params T[] entity)
        {
            await _table.AddRangeAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(U id)
        {
            T entity = await Get(id);
            return await Delete(entity);
        }

        public async Task<T> Delete(T entity)
        {
            _table.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(U id, string idField, params Func<IQueryable<T>, IQueryable<T>>[] includeChains)
        {
            IQueryable<T> query = GetIncludeTable(includeChains);
            T? entity = await query.FirstOrDefaultAsync(e => EF.Property<U>(e, idField).Equals(id));
            return entity ?? throw new IdNotFoundException($"That ID does not exist for {typeof(T).Name}");
        }

        public async Task<T> GetComposite(U[] id, string[] idFields, params Func<IQueryable<T>, IQueryable<T>>[] includeChains)
        {
            if (id.Length != idFields.Length)
            {
                throw new ArgumentException("The number of IDs and ID fields must match");
            }
            IQueryable<T> query = GetIncludeTable(includeChains);
            var predicate = PredicateBuilder.New<T>(true);
            for (int i = 0; i < id.Length; i++)
            {
                int index = i;
                predicate = predicate.And(e => Equals(EF.Property<object>(e, idFields[index]), id[index]));
            }
            T? entity = await query.Where(predicate).FirstOrDefaultAsync();
            return entity ?? throw new IdNotFoundException($"That ID does not exist for {typeof(T).Name}");
        }
        public async Task<T> Get(U id, params Func<IQueryable<T>, IQueryable<T>>[] includeChains)
        {
            return await Get(id, "Id", includeChains);
        }

        public async Task<IEnumerable<T>> GetAll(params Func<IQueryable<T>, IQueryable<T>>[] includeChains)
        {
            IQueryable<T> query = GetIncludeTable(includeChains);
            return await query.ToListAsync();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<T> Find(Expression<Func<T, bool>> condition, params Func<IQueryable<T>, IQueryable<T>>[] includeChains)
        {
            IQueryable<T> query = GetIncludeTable(includeChains);
            T? entity = await query.FirstOrDefaultAsync(condition);
            return entity ?? throw new IdNotFoundException($"That ID does not exist for {typeof(T).Name}");
        }

        public async Task<T> Update(T entity)
        {
            _table.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> FindAll(
            Expression<Func<T, bool>>? condition = null,
            Expression<Func<T, object>>? orderBy = null,
            bool ascending = true,
            params Func<IQueryable<T>, IQueryable<T>>[] includeChains)
        {
            IQueryable<T> query = GetIncludeTable(includeChains);

            if (condition != null)
            {
                query = query.Where(condition);
            }
            if (orderBy != null)
            {
                query = ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);
            }
            return await query.ToListAsync();
        }
        private IQueryable<T> GetIncludeTable(params Func<IQueryable<T>, IQueryable<T>>[] includeChains)
        {
            IQueryable<T> query = _table;
            foreach (var includeChain in includeChains)
            {
                query = includeChain(query);
            }
            return query;
        }
    }
}

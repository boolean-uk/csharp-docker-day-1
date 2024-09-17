using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Runtime.CompilerServices;

namespace exercise.wwwapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext _db;
        private DbSet<T> _table;
        public Repository(DataContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public async Task<T> CreateObject(IFilter<T> filter, T entity)
        {
            T newEntity = filter.AssignIdToEntity(_table.AsQueryable(), entity);
            _table.Add(entity);
            await _db.SaveChangesAsync();
            return newEntity;
        }

        public async Task<T> DeleteObject(IFilter<T> filter, int id)
        {
            T newEntity = GetObject(filter, id);
            _table.Remove(newEntity);
            await _db.SaveChangesAsync();
            return newEntity;
        }

        public T GetObject(IFilter<T> filter, int id)
        {
            return filter.FilterById(_table.AsQueryable(), id).First();
        }

        public async Task<IEnumerable<T>> GetObjects()
        {
            return await _db.Set<T>().ToListAsync();
        }


        public async Task<T> UpdateObject(IFilter<T> filter, int id, string stringOne, string stringTwo, DateTime date)
        {
            T newEntity = filter.AssignNewData(_db, id, stringOne, stringTwo, date);
            return newEntity;
        }
    }
}

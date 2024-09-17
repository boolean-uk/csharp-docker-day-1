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

        public T DeleteObject(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetObject(IFilter<T> filter, int id)
        {
            return filter.FilterById(_table.AsQueryable(), id).First();
        }

        public async Task<IEnumerable<T>> GetObjects()
        {
            return await _db.Set<T>().ToListAsync();
        }


        public T UpdateObject(int id, string stringOne, string stringTwo, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}

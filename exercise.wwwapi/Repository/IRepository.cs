﻿
namespace exercise.wwwapi.Repository.GenericRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Insert(T entity);
        Task<IEnumerable<T>> Get();
        Task<T> Update(T entity);
        Task<T> Delete(object id);
        Task<T> Delete(object id_1, object id_2);
        Task<T> Delete(T entity);
        Task<T> GetById(object id);
        Task<T> GetById(object id_1, object id_2);



    }
}

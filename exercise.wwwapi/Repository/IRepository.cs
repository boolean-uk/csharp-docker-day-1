﻿using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }

}

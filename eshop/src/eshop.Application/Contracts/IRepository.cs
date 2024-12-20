﻿using eshop.Domain;

namespace eshop.Application.Contracts
{
    public interface IRepository<TEntity> where TEntity : class, IEntity, new()
    {

        //Varyans:
        //Covaryans: out
        //Contravaryans: in
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);

        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}

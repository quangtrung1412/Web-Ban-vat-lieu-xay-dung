namespace App.Shared.Core.Repositories;

public interface IRepositories<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAll();
    Task<TEntity> GetById(string id);
    Task<TEntity> Add(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task<TEntity> Delete(string id);
    void SaveChangesAsync();
}
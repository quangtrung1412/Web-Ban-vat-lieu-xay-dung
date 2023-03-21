namespace App.Shared.Core.Service;

public interface IService<TEntity> where TEntity : class
{
    Task<TEntity> GetById(string id);
    Task<TEntity> Add(TEntity entity);
    Task<TEntity> Delete(string id);
    Task<List<TEntity>> GetAll(string search, int page = 1);
}
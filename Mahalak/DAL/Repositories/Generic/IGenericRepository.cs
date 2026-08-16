namespace Mahalak;
public interface IGenericRepository<TEntity>
where TEntity:class
{
    Task<List<TEntity>> GetAllAsync(CancellationToken ct);
    Task<List<TEntity>> GetPaginatedAsync(int pageNumber, int pageSize, CancellationToken ct);
    Task<int> GetCountAsync(CancellationToken ct);
    Task<TEntity?> GetByIdAsync(int? id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void DeleteById(int id);
    void RemoveRange(IQueryable<TEntity> entities);

}
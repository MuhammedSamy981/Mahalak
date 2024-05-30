namespace Mahalak;
public interface IGenericRepository<TEntity>
where TEntity:class
{
    List<TEntity> GetAll();
    TEntity? GetById(int? id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void DeleteById(int id);

}
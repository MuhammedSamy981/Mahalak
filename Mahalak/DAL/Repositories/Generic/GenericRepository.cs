
namespace Mahalak;
public class GenericRepository<TEntity> : IGenericRepository<TEntity>
where TEntity : class
{
    private readonly MahalakContext mahalakContext;

    public GenericRepository(MahalakContext mahalakContext)
    {
        this.mahalakContext = mahalakContext;
    }
    public List<TEntity> GetAll()
    {
        return mahalakContext.Set<TEntity>().ToList();
    }


    public TEntity? GetById(int? id)
    {
        return mahalakContext.Set<TEntity>().Find(id);
    }

    public void Add(TEntity entity)
    {
        mahalakContext.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        mahalakContext.Set<TEntity>().Update(entity);
    }
    public void DeleteById(int id)
    {
        var entity = mahalakContext.Set<TEntity>().Find(id);
        if (entity != null)
        {
            mahalakContext.Set<TEntity>().Remove(entity);
        }
    }



}

using Microsoft.EntityFrameworkCore;

namespace Mahalak;
public class GenericRepository<TEntity> : IGenericRepository<TEntity>
where TEntity : class
{
    private readonly MahalakDbContext mahalakDbContext;

    public GenericRepository(MahalakDbContext mahalakDbContext)
    {
        this.mahalakDbContext = mahalakDbContext;
    }
/*    public List<TEntity> GetAll()
    {
        return mahalakDbContext.Set<TEntity>().AsNoTracking().ToList();
    }*/

    public async Task<List<TEntity>> GetAllAsync(CancellationToken ct)
    {
        return await mahalakDbContext.Set<TEntity>().AsNoTracking().ToListAsync(ct);
    }
    public async Task<List<TEntity>> GetPaginatedAsync(int pageNumber,int pageSize, CancellationToken ct)
    {
        return await mahalakDbContext.Set<TEntity>().AsNoTracking().Skip((pageNumber - 1) * pageSize)
        .Take(pageSize).ToListAsync(ct);
    }

    public async Task<int> GetCountAsync(CancellationToken ct)
    {
      return await mahalakDbContext.Set<TEntity>().AsNoTracking().CountAsync(ct);
    }

/*    public TEntity? GetById(int? id)
    {
        return mahalakDbContext.Set<TEntity>().Find(id);
    }*/

      public async Task<TEntity?> GetByIdAsync(int? id)
  {
    return await mahalakDbContext.Set<TEntity>().FindAsync(id);
  }

    public void Add(TEntity entity)
    {
        mahalakDbContext.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        mahalakDbContext.Set<TEntity>().Update(entity);
    }
    public void DeleteById(int id)
    {
        var entity = mahalakDbContext.Set<TEntity>().Find(id);
        if (entity != null)
        {
            mahalakDbContext.Set<TEntity>().Remove(entity);
        }
    }

    public void RemoveRange(IQueryable<TEntity> entities)
    {
         mahalakDbContext.Set<TEntity>().RemoveRange(entities);
    }

}
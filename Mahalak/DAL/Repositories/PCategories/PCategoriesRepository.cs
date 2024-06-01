
namespace Mahalak;
public class PCategoriesRepository : GenericRepository<PCategory>,IPCategoriesRepository
{
    private readonly MahalakContext mahalakContext;
    public PCategoriesRepository(MahalakContext mahalakContext) : base(mahalakContext)
    {
         this.mahalakContext=mahalakContext;
    }

    public List<PCategory> GetAllBySCategoryId(int id)
    {
        return mahalakContext.Set<PCategory>()
        .Where(pc=>pc.SCategoryID==id).ToList();
    }

}
namespace Mahalak;
public class SCategoriesRepository : GenericRepository<SCategory>,ISCategoriesRepository
{
    public SCategoriesRepository(MahalakContext mahalakContext) : base(mahalakContext)
    {
         
    }
}
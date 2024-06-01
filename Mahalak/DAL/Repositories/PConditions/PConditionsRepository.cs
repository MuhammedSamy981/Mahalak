namespace Mahalak;
public class PConditionsRepository : GenericRepository<PCondition>,IPConditionsRepository
{
    public PConditionsRepository(MahalakContext mahalakContext) : base(mahalakContext)
    {
        
    }
}
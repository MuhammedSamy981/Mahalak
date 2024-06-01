namespace Mahalak;
public class UnitOfWork : IUnitOfWork
{
    public IUsersRepository UsersRepository {get;}

    public IShopsRepository ShopsRepository {get;}

    public ISCategoriesRepository SCategoriesRepository {get;}

    public ISCountriesRepository SCountriesRepository {get;}

    public ISCitiesRepository SCitiesRepository {get;}

    public ISAreasRepository SAreasRepository {get;}

    public IRatingsRepository RatingsRepository {get;}

    public IProductsRepository ProductsRepository {get;}

    public IPCategoriesRepository PCategoriesRepository {get;}

    public IPConditionsRepository PConditionsRepository {get;}

    public IProductImagesRepository ProductImagesRepository {get;}

    public IMailService MailService{get;}

    private readonly MahalakContext mahalakContext;
    public UnitOfWork
    (MahalakContext mahalakContext,
     IUsersRepository usersRepository,
     IShopsRepository shopsRepository,
     ISCategoriesRepository sCategoriesRepository,
     ISCountriesRepository sCountriesRepository,
     ISCitiesRepository sCitiesRepository,
     ISAreasRepository sAreasRepository,
     IRatingsRepository ratingsRepository,
     IProductsRepository productsRepository,
     IPCategoriesRepository pCategoriesRepository,
     IPConditionsRepository pConditionsRepository,
     IProductImagesRepository productImagesRepository,
     IMailService mailService)
    {
      this.mahalakContext=mahalakContext;
      UsersRepository=usersRepository;
      ShopsRepository=shopsRepository;
      SCategoriesRepository=sCategoriesRepository;
      SCountriesRepository=sCountriesRepository;
      SCitiesRepository=sCitiesRepository;
      SAreasRepository=sAreasRepository;
      RatingsRepository=ratingsRepository;
      ProductsRepository=productsRepository;
      PCategoriesRepository=pCategoriesRepository;
      PConditionsRepository=pConditionsRepository;
      ProductImagesRepository=productImagesRepository;
      MailService=mailService;
    }
    public int SaveChanges()
    {
       return mahalakContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
       return await mahalakContext.SaveChangesAsync();
    }
 
}
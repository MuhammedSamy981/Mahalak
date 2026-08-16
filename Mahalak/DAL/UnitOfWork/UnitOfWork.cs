namespace Mahalak;
public class UnitOfWork : IUnitOfWork
{
  private readonly MahalakDbContext mahalakDbContext;

  public IUsersRepository UsersRepository { get; }

  public IShopsRepository ShopsRepository { get; }

  public ISCategoriesRepository SCategoriesRepository { get; }

  public ISCountriesRepository SCountriesRepository { get; }

  public ISCitiesRepository SCitiesRepository { get; }

  public ISAreasRepository SAreasRepository { get; }

  public IRatingsRepository RatingsRepository { get; }

  public IProductsRepository ProductsRepository { get; }

  public IPCategoriesRepository PCategoriesRepository { get; }

  public IPConditionsRepository PConditionsRepository { get; }

  public IProductImagesRepository ProductImagesRepository { get; }

  public IMailService MailService { get; }

  public IGmailAPIService GmailAPIService { get; }

  public ICloudStorageService CloudStorageService { get; }

  public UnitOfWork(
    MahalakDbContext mahalakDbContext,
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
    IMailService mailService,
    IGmailAPIService gmailAPIService,
    ICloudStorageService cloudStorageService)
  {
     this.mahalakDbContext = mahalakDbContext;
     UsersRepository = usersRepository;
     ShopsRepository = shopsRepository;
     SCategoriesRepository = sCategoriesRepository;
     SCountriesRepository = sCountriesRepository;
     SCitiesRepository = sCitiesRepository;
     SAreasRepository = sAreasRepository;
     RatingsRepository = ratingsRepository;
     ProductsRepository = productsRepository;
     PCategoriesRepository = pCategoriesRepository;
     PConditionsRepository = pConditionsRepository;
     ProductImagesRepository = productImagesRepository;
     MailService = mailService;
     GmailAPIService = gmailAPIService;
     CloudStorageService = cloudStorageService;
  }

  public int SaveChanges() => mahalakDbContext.SaveChanges();

  public async Task<int> SaveChangesAsync() => await mahalakDbContext.SaveChangesAsync();
}
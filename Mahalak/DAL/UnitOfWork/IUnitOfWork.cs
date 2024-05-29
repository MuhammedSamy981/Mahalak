namespace Mahalak;
public interface IUnitOfWork
{
    public IUsersRepository UsersRepository{get;}

    public IShopsRepository ShopsRepository{get;}

    public ISCategoriesRepository SCategoriesRepository{get;}

    public ISCountriesRepository SCountriesRepository{get;}

    public ISCitiesRepository SCitiesRepository{get;}

    public ISAreasRepository SAreasRepository{get;}

    public IRatingsRepository RatingsRepository{get;}

    public IProductsRepository ProductsRepository{get;}

    public IPCategoriesRepository PCategoriesRepository{get;}

    public IPConditionsRepository PConditionsRepository{get;}

    public IProductImagesRepository ProductImagesRepository{get;}

    public IMailService MailService{get;}
    
    int SaveChanges();
    
    Task<int> SaveChangesAsync();

    

}
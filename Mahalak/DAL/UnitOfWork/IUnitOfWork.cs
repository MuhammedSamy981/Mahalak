namespace Mahalak;
public interface IUnitOfWork
{
  IUsersRepository UsersRepository { get; }

  IShopsRepository ShopsRepository { get; }

  ISCategoriesRepository SCategoriesRepository { get; }

  ISCountriesRepository SCountriesRepository { get; }

  ISCitiesRepository SCitiesRepository { get; }

  ISAreasRepository SAreasRepository { get; }

  IRatingsRepository RatingsRepository { get; }

  IProductsRepository ProductsRepository { get; }

  IPCategoriesRepository PCategoriesRepository { get; }

  IPConditionsRepository PConditionsRepository { get; }

  IProductImagesRepository ProductImagesRepository { get; }

  IMailService MailService { get; }

  IGmailAPIService GmailAPIService { get; }

  ICloudStorageService CloudStorageService { get; }

  int SaveChanges();

  Task<int> SaveChangesAsync();
}
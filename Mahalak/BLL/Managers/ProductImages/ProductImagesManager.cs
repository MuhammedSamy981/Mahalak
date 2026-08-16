
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;

namespace Mahalak;
public class ProductImagesManager : IProductImagesManager
{
    private readonly UserManager<User> userManager;
    private readonly IUnitOfWork unitOfWork;
    private readonly IWebHostEnvironment webHostEnvironment;

  public ProductImagesManager(UserManager<User> userManager,IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
  {
    
    this.userManager = userManager;
    this.unitOfWork =unitOfWork;
     this.webHostEnvironment = webHostEnvironment;
  }

  public async Task<List<ProductImageDTO>> GetAllAsync(CancellationToken ct=default)
  {
    var images=await unitOfWork.ProductImagesRepository.GetAllAsync(ct);
    return images.Select(i => new ProductImageDTO
    {
      Id = i.Id,
      Name = i.Name,
      ProductId = i.ProductId
    }).ToList();
  }

  public async Task<List<ProductImageDTO>> GetAllByProductIdAsync(int? id, CancellationToken ct=default)
  {
    var images = await unitOfWork.ProductImagesRepository.GetAllByProductIdAsync(id,ct);
    return images.Select(i => new ProductImageDTO
    {
      Id = i.Id,
      Name = i.Name,
      ProductId = i.ProductId
    }).ToList();
  }

  public async Task<ProductImageDTO?> GetByIdAsync(int id)
  {
    var productImage = await  unitOfWork.ProductImagesRepository.GetByIdAsync(id);
    if (productImage == null)
      return null;
    return new ProductImageDTO
    {
      Id = productImage.Id,
      Name = productImage.Name,
      ProductId = productImage.ProductId
    };
  }

  /*  public async Task<string[]> ShowUploadedImages(IFormFile[]? images, string userId)
    {
      var user = await userManager.FindByIdAsync(userId);
      if (user != null)
      {
        if (images == null)
          return Array.Empty<string>();
        string[] imagesToShow = new string[images.Length];
        for (int i = 0; i < images.Length; ++i)
        {
          string path = Path.Combine(Path.Combine(webHostEnvironment.WebRootPath, "images/temporary/" + user!.Id.ToString()), images[i].FileName);
          Directory.CreateDirectory(Path.GetDirectoryName(path)!);
          using (FileStream stream = File.Create(path))
          {
            await images[i].CopyToAsync(stream);
            imagesToShow[i] = $"{user.Id}/{images[i].FileName}";
          }
        }
        return imagesToShow;
      }
      return Array.Empty<string>();
    }

    public async Task AddCollectionAsync(string[] productImages, string userId)
    {
      var user =  await userManager.FindByIdAsync(userId);
      if (user != null)
      {
        List<Product> products = await unitOfWork.ProductsRepository.GetAllAsync();
        Console.WriteLine("\n\n" + productImages[0]);
        foreach (string str in await unitOfWork.CloudStorageService.Upload(productImages))
          await AddAsync(new AddProductImageDTO()
          {
            ProductId = products[products.Count - 1].Id,
            Name = str
          });
      }
    }*/
  
      public async Task AddCollectionAsync(List<IFormFile> productImages, string userId,CancellationToken ct=default)
    {
      var user =  await userManager.FindByIdAsync(userId);
      if (user != null)
      {
        List<Product> products = await unitOfWork.ProductsRepository.GetAllAsync(ct);
        Console.WriteLine("\n\n" + productImages[0]);
             // var productImageNames = productImages.Select(pimg => user.Id + "/" + pimg.Name);
        foreach (string str in await unitOfWork.CloudStorageService.Upload(productImages))
          await AddAsync(new ProductImageAddDTO()
          {
            ProductId = products[products.Count - 1].Id,
            Name = str
          });
      }
    }

  public async Task AddAsync(ProductImageAddDTO productImageDTO)
  {
     unitOfWork.ProductImagesRepository.Add(new ProductImage()
    {
      Name = productImageDTO.Name,
      ProductId = productImageDTO.ProductId
    });
    int num = await  unitOfWork.SaveChangesAsync();
  }

  public async Task UpdateCollectionAsync(
    List<IFormFile> newProductImages,
    int ProductId,
    string userId, CancellationToken ct=default)
  {
   var user =  await userManager.FindByIdAsync(userId);
    if (user != null)
    {
      List<ProductImageDTO> oldProductImages = await GetAllByProductIdAsync(ProductId,ct);
      List<string> newProductImageNames = await unitOfWork.CloudStorageService.Upload(newProductImages);
      for (int i = 0; i < newProductImageNames.Count; ++i)
      {
        if (await UpdateAsync(new ProductImageUpdateDTO()
        {
          Id = oldProductImages[i].Id,
          Name = newProductImageNames[i]
        }))
          await unitOfWork.CloudStorageService.Delete(oldProductImages[i].Name);
      }
    }
  }

  public async Task<bool> UpdateAsync(ProductImageUpdateDTO productImageDTO)
  {
    var productImage = await  unitOfWork.ProductImagesRepository.GetByIdAsync(productImageDTO.Id);
    if (productImage == null)
      return false;
    productImage.Name = productImageDTO.Name;
    unitOfWork.ProductImagesRepository.Update(productImage);
    return await unitOfWork.SaveChangesAsync() > 0;
  }

  public async Task<bool> DeleteCollectionAsync(int ProductId, CancellationToken ct=default)
  {
    var productImages= await unitOfWork.ProductImagesRepository.GetAllByProductIdAsync(ProductId,ct);
    foreach (ProductImage productImage in productImages)
      await  unitOfWork.CloudStorageService.Delete(productImage.Name);
      return true;
  }

  public async Task DeleteTemporaryImages(string userId)
  {
     var user = await userManager.FindByIdAsync(userId);
         if (user != null)
         {
           foreach (DirectoryInfo directory in new DirectoryInfo(Path.Combine(webHostEnvironment.WebRootPath, "images/temporary")).GetDirectories(user.Id.ToString()))
           directory.Delete(true);
         }
  }
}

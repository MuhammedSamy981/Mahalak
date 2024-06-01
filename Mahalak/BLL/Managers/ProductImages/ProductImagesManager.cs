
using System.Runtime.CompilerServices;

namespace Mahalak;
public class ProductImagesManager : IProductImagesManager
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IWebHostEnvironment webHostEnvironment;

    public ProductImagesManager(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        this.unitOfWork = unitOfWork;
        this.webHostEnvironment = webHostEnvironment;
    }

    public List<GetAllProductImagesDTO> GetAll()
    {
        var images = unitOfWork.ProductImagesRepository.GetAll();
        return images.Select(i => new GetAllProductImagesDTO
        {
            ID = i.ID,
            Name = i.Name,
            ProductID = i.ProductID
        }).ToList();
    }

    public List<GetAllProductImagesByProductIdDTO> GetAllByProductId(int? id)
    {
        var images = unitOfWork.ProductImagesRepository.GetAllByProductId(id);
        return images.Select(i => new GetAllProductImagesByProductIdDTO
        {
            ID = i.ID,
            Name = i.Name,
            ProductID = i.ProductID
        }).ToList();
    }

    public GetProductImageByIdDTO? GetById(int id)
    {
        var image = unitOfWork.ProductImagesRepository.GetById(id);
        if (image == null)
        {
            return null;
        }

        return new GetProductImageByIdDTO
        {
            ID = image.ID,
            Name = image.Name,
            ProductID = image.ProductID
        };
    }
    public string[] ShowUploadedImages(IFormFile[]? images)
    {
        if (images != null)
        {
            string[] imagesToShow = new string[images.Length];
            for (int i = 0; i < images.Length; i++)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/temporery");
                string uniqueName = Guid.NewGuid().ToString() + "_" + images[i].FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    images[i].CopyTo(stream);
                    imagesToShow[i] = uniqueName;
                }
            }
            return imagesToShow;
        }
        return null;
    }

    public bool DeleteTemporeryImages(string[]? images)
    {
        if (images != null)
        {
            string folderPath = Path.Combine(webHostEnvironment.WebRootPath, "images/temporery");
            foreach (var image in images)
            {
                string fullPath = Path.Combine(folderPath, image);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
        }
        return true;

    }

    public void AddCollection(string[] productImages)
    {
        var products = unitOfWork.ProductsRepository.GetAll();

        for (int i = 0; i < productImages.Length; i++)
        {
            AddProductImageDTO productImageDTO = new AddProductImageDTO
            {
                ProductID = products[products.Count - 1].ID,
                Name = productImages[i]
            };
            Add(productImageDTO);
        }
    }

    public bool Add(AddProductImageDTO productImageDTO)
    {
        string uniqueName = UploadedImage(productImageDTO.Name);
        ProductImage image = new ProductImage
        {
            Name = uniqueName,
            ProductID = productImageDTO.ProductID
        };
        unitOfWork.ProductImagesRepository.Add(image);
        unitOfWork.SaveChanges();
        return true;
    }
    public void UpdateCollection(string[] newProductImages, int ProductID)
    {
        var oldProductImages = GetAllByProductId(ProductID);

        for (int i = 0; i < newProductImages.Length; i++)
        {
            UpdateProductImageDTO productImageDTO = new UpdateProductImageDTO
            {
                ID = oldProductImages[i].ID,
                Name = newProductImages[i]
            };
            Update(productImageDTO);
        }
    }

    public bool Update(UpdateProductImageDTO productImageDTO)
    {
        var image = unitOfWork.ProductImagesRepository.GetById(productImageDTO.ID);
        if (image == null)
        {
            return false;
        }
        string uniqueName = UploadedImage(productImageDTO.Name);
        image.Name = uniqueName;

        unitOfWork.ProductImagesRepository.Update(image);
        unitOfWork.SaveChanges();
        return true;
    }
    private string UploadedImage(string Name)
    {

        if (Name != null)
        {
            string uploadsFolder1 = Path.Combine(webHostEnvironment.WebRootPath, "images/temporery");
            string filePath1 = Path.Combine(uploadsFolder1, Name);

            string uploadsFolder2 = Path.Combine(webHostEnvironment.WebRootPath, "images/productImages");
            string filePath2 = Path.Combine(uploadsFolder2, Name);


            File.Move(filePath1, filePath2);
        }
        return Name;
    }
    public bool Delete(int id)
    {
        var image = unitOfWork.ProductImagesRepository.GetById(id);
        if (image == null)
        {
            return false;
        }

        unitOfWork.ProductImagesRepository.DeleteById(id);
        unitOfWork.SaveChanges();
        return true;
    }


}
namespace Mahalak;
public interface IProductImagesManager
{
    List<GetAllProductImagesDTO> GetAll();
    List<GetAllProductImagesByProductIdDTO> GetAllByProductId(int? id);
    GetProductImageByIdDTO? GetById(int id);
    string[] ShowUploadedImages(IFormFile[]? images);
    void DeleteTemporeryImages(string[]? images);
    void AddCollection(string[] productImages);
    void UpdateCollection(string[] newProductImages,int ProductID);
    bool Delete(int id);
}
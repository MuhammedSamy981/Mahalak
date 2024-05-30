namespace Mahalak;
public interface IProductsManager
{
    List<GetAllPaginatedProductsDTO> GetAllPaginated(int pageSize,int pageNumber);
    List<GetAllPaginatedProductsByNameDTO> GetAllPaginatedByName(string name,
    int pageSize,int pageNumber);
    GetProductByIdDTO? GetById(int? id);
    GetAllProductDetailsByIdDTO? GetAllDetailsById(int? id);
    List<GetAllPaginatedProductsByShopIdDTO> GetAllPaginatedByShopId(int id,int pageSize,int pageNumber);
    bool Add(AddProductDTO productDTO);
    bool Update(UpdateProductDTO productDTO);
    bool Delete(int id);
    bool VerifyField(int value);
    void EditStatus(int id, string status);
}
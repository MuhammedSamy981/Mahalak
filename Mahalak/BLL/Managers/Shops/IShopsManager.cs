namespace Mahalak;
public interface IShopsManager
{
    List<GetAllPaginatedShopsDTO> GetAllPaginated(int pageSize,int pageNumber);
    List<GetAllPaginatedShopsByNameDTO> GetAllPaginatedByName(string name,int pageSize,int pageNumber);
    List<GetAllPaginatedShopsWithFilterDTO> GetAllPaginatedWithFilter(int pageSize,
    int pageNumber,int categoryID, int countryID, int cityID, int areaID);
    public List<GetAllPaginatedShopsByUserIdDTO> GetAllPaginatedByUserId(Guid id,int pageSize,int pageNumber);
    GetShopByIdDTO? GetById(int? id);
    GetShopDetailsByIdDTO? GetAllDetailsById(int? id);
    void Add(AddShopDTO shopDTO);
    bool Update(UpdateShopDTO shopDTO);
    bool Delete(int id);
    bool VerifyField(string value);
    public bool VerifyEditField(string value, int? id);
    bool VerifyField(int value);
    void EditStatus(int id, string status);
    void EditDistinctive(int id, bool distinctive, int period);
    Task<bool> CheckDistinctivePeriod();
}
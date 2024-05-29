namespace Mahalak;
public interface IPCategoriesManager
{
    List<GetAllPCategoriesDTO> GetAll();
    GetPCategoryByIdDTO? GetById(int id);
    List<GetAllPCategoriesBySCategoryIdDTO> GetAllBySCategoryId(int id);
    void Add(AddPCategoryDTO subCategoryDTO);
    bool Update(UpdatePCategoryDTO subCategoryDTO);
    bool Delete(int id);
}
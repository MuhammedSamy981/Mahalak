namespace Mahalak;
public interface ISCategoriesManager
{
    List<GetAllSCategoriesDTO> GetAll();
    GetSCategoryByIdDTO? GetById(int id);
    void Add(AddSCategoryDTO sCategoryDTO);
    bool Update(UpdateSCategoryDTO sCategoryDTO);
    bool Delete(int id);
}
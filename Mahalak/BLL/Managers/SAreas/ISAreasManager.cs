namespace Mahalak;
public interface ISAreasManager
{
    List<GetAllSAreasDTO> GetAll();
    List<GetAllSAreasByCityIdDTO> GetAllByCityId(int id);
    GetSAreaByIdDTO? GetById(int id);
    void Add(AddSAreaDTO sAreaDTO);
    bool Update(UpdateSAreaDTO sAreaDTO);
    bool Delete(int id);
}
namespace Mahalak;
public interface ISCitiesManager
{
    List<GetAllSCitiesDTO> GetAll();
    List<GetAllSCitiesByCountryIdDTO> GetAllByCountryId(int id);
    GetSCityByIdDTO? GetById(int id);
    void Add(AddSCityDTO sCityDTO);
    bool Update(UpdateSCityDTO sCityDTO);
    bool Delete(int id);
}
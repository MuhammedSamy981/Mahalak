namespace Mahalak;
public interface ISCountriesManager
{
    List<GetAllSCountriesDTO> GetAll();
    GetSCountryByIdDTO? GetById(int id);
    void Add(AddSCountryDTO sCountryDTO);
    bool Update(UpdateSCountryDTO sCountryDTO);
    bool Delete(int id);
}
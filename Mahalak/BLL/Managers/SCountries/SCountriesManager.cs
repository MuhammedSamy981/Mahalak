namespace Mahalak;
public class SCountriesManager : ISCountriesManager
{
    private readonly IUnitOfWork unitOfWork;

    public SCountriesManager(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public List<GetAllSCountriesDTO> GetAll()
    {
        var countries = unitOfWork.SCountriesRepository.GetAll();
        return countries.Select(c => new GetAllSCountriesDTO
        {
            ID = c.ID,
            Name = c.Name
        }).ToList();
    }

    public GetSCountryByIdDTO? GetById(int id)
    {
        var country = unitOfWork.SCountriesRepository.GetById(id);
        if (country != null)
        {
            return new GetSCountryByIdDTO
            {
                ID = country.ID,
                Name = country.Name
            };
        }
        return null;
    }

    public void Add(AddSCountryDTO countryDTO)
    {
        SCountry country=new SCountry
        {
            ID=countryDTO.ID,
            Name=countryDTO.Name
        };
        unitOfWork.SCountriesRepository.Add(country);
        unitOfWork.SaveChanges();

    }

    public bool Update(UpdateSCountryDTO countryDTO)
    {
        var country=unitOfWork.SCountriesRepository.GetById(countryDTO.ID);
        if(country==null)
        {
            return false;
        }
        country.Name=countryDTO.Name;
        unitOfWork.SCountriesRepository.Update(country);
        unitOfWork.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var country=unitOfWork.SCountriesRepository.GetById(id);
        if(country==null)
        {
            return false;
        }
        unitOfWork.SCountriesRepository.DeleteById(id);
        unitOfWork.SaveChanges();
        return true;
    }
}

namespace Mahalak;
public class SCitiesManager : ISCitiesManager
{
    private readonly IUnitOfWork unitOfWork;

    public SCitiesManager(IUnitOfWork unitOfWork)
    {
      this.unitOfWork=unitOfWork;
    }

    public List<GetAllSCitiesDTO> GetAll()
    {
        var cities=unitOfWork.SCitiesRepository.GetAll();
        return cities.Select(c=>new GetAllSCitiesDTO
        {
            ID=c.ID,
            Name=c.Name,
            CountryID=c.CountryID
        }).ToList();
    }

    public List<GetAllSCitiesByCountryIdDTO> GetAllByCountryId(int id)
    {
       var cities=unitOfWork.SCitiesRepository.GetAllByCountryId(id);
        return cities.Select(c=>new GetAllSCitiesByCountryIdDTO
        {
            ID=c.ID,
            Name=c.Name,
            CountryID=c.CountryID
        }).ToList();
    }

    public GetSCityByIdDTO? GetById(int id)
    {
        var city=unitOfWork.SCitiesRepository.GetById(id);
        if(city==null)
        {
            return null;
        }

        return new GetSCityByIdDTO
        {
            ID=city.ID,
            Name=city.Name,
            CountryID=city.CountryID
        };
    }

    public void Add(AddSCityDTO sCityDTO)
    {
       SCity city=new SCity
       {
            ID=sCityDTO.ID,
            Name=sCityDTO.Name,
            CountryID=sCityDTO.CountryID
       };

       unitOfWork.SCitiesRepository.Add(city);
       unitOfWork.SaveChanges();
       
    }

    public bool Update(UpdateSCityDTO sCityDTO)
    {
        var city=unitOfWork.SCitiesRepository.GetById(sCityDTO.ID);
        if(city==null)
        {
            return false;
        }
        city.Name=sCityDTO.Name;
        city.CountryID=sCityDTO.CountryID;

       unitOfWork.SCitiesRepository.Update(city);
       unitOfWork.SaveChanges();  
       return true; 
    }
    
    public bool Delete(int id)
    {
        var city=unitOfWork.SCitiesRepository.GetById(id);
        if(city==null)
        {
            return false;
        }

       unitOfWork.SCitiesRepository.DeleteById(id);
       unitOfWork.SaveChanges();  
       return true; 
    }


}
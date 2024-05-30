namespace Mahalak;
public class SAreasManager : ISAreasManager
{
    
    private readonly IUnitOfWork unitOfWork;

    public SAreasManager(IUnitOfWork unitOfWork)
    {
      this.unitOfWork=unitOfWork;
    }

    public List<GetAllSAreasDTO> GetAll()
    {
        var areas=unitOfWork.SAreasRepository.GetAll();
        return areas.Select(a=>new GetAllSAreasDTO
        {
            ID=a.ID,
            Name=a.Name,
            CityID=a.CityID
        }).ToList();
    }

    public List<GetAllSAreasByCityIdDTO> GetAllByCityId(int id)
    {
        var areas=unitOfWork.SAreasRepository.GetAllByCityId(id);
        return areas.Select(a=>new GetAllSAreasByCityIdDTO
        {
            ID=a.ID,
            Name=a.Name,
            CityID=a.CityID
        }).ToList();
    }

    public GetSAreaByIdDTO? GetById(int id)
    {
        var Area=unitOfWork.SAreasRepository.GetById(id);
        if(Area==null)
        {
            return null;
        }

        return new GetSAreaByIdDTO
        {
            ID=Area.ID,
            Name=Area.Name,
            CityID=Area.CityID
        };
    }

    public void Add(AddSAreaDTO sAreaDTO)
    {
       SArea area=new SArea
       {
            ID=sAreaDTO.ID,
            Name=sAreaDTO.Name,
            CityID=sAreaDTO.CityID
       };

       unitOfWork.SAreasRepository.Add(area);
       unitOfWork.SaveChanges();
       
    }

    public bool Update(UpdateSAreaDTO sAreaDTO)
    {
        var area=unitOfWork.SAreasRepository.GetById(sAreaDTO.ID);
        if(area==null)
        {
            return false;
        }
        area.Name=sAreaDTO.Name;
        area.CityID=sAreaDTO.CityID;

       unitOfWork.SAreasRepository.Update(area);
       unitOfWork.SaveChanges();  
       return true; 
    }
    
    public bool Delete(int id)
    {
        var area=unitOfWork.SAreasRepository.GetById(id);
        if(area==null)
        {
            return false;
        }

       unitOfWork.SAreasRepository.DeleteById(id);
       unitOfWork.SaveChanges();  
       return true; 
    }


}
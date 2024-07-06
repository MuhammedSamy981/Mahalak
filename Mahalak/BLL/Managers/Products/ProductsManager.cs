
namespace Mahalak;
public class ProductsManager : IProductsManager
{
    private readonly IUnitOfWork unitOfWork;

    public ProductsManager(IUnitOfWork unitOfWork)
    {
      this.unitOfWork=unitOfWork;
    }

    public List<GetAllPaginatedProductsDTO> GetAllPaginated(int pageSize,int pageNumber)
    {
        var products=unitOfWork.ProductsRepository.GetAll();

         int listEnd=pageSize*pageNumber;
      int listStart=listEnd-pageSize;
      if(pageSize>products.Count-listStart)
      {
        pageSize=products.Count-listStart;
      }
        return products.Select(p=>new GetAllPaginatedProductsDTO
        {
            ID=p.ID,
            Name=p.Name,
            Price=p.Price,
            Status=p.Status,
            AddingDate=p.AddingDate,
            CategoryID=p.CategoryID,
            ConditionID=p.ConditionID,
            ProductsCount=products.Count,
            ShopID=p.ShopID
        }).ToList().GetRange(listStart,pageSize);
    }

    public List<GetAllPaginatedProductsByNameDTO> GetAllPaginatedByName(string name,
    int pageSize,int pageNumber)
    {
        var products=unitOfWork.ProductsRepository.GetAllByName(name);
              int listEnd=pageSize*pageNumber;
      int listStart=listEnd-pageSize;
      if(pageSize>products.Count-listStart)
      {
        pageSize=products.Count-listStart;
      }
        return products.Select(p=>new GetAllPaginatedProductsByNameDTO
        {
            ID=p.ID,
            Name=p.Name,
            Price=p.Price,
            Status=p.Status,
            AddingDate=p.AddingDate,
            CategoryID=p.CategoryID,
            ConditionID=p.ConditionID,
         ProductsCount=products.Count,
            ShopID=p.ShopID
        }).ToList().GetRange(listStart,pageSize);
    }
        


    public List<GetAllPaginatedProductsByShopIdDTO> GetAllPaginatedByShopId(int id,int pageSize,int pageNumber)
    {
        var products=unitOfWork.ProductsRepository.GetAllByShopId(id);
      int listEnd=pageSize*pageNumber;
      int listStart=listEnd-pageSize;
      if(pageSize>products.Count-listStart)
      {
        pageSize=products.Count-listStart;
      }
        return products.Select(p=>new GetAllPaginatedProductsByShopIdDTO
        {
            ID=p.ID,
            Name=p.Name,
            Price=p.Price,
            Status=p.Status,
            AddingDate=p.AddingDate,
            ConditionID=p.ConditionID,
            ProductsCount=products.Count,
            ShopID=p.ShopID
        }).ToList().GetRange(listStart,pageSize); 
    }

    public GetProductByIdDTO? GetById(int? id)
    {
        var product=unitOfWork.ProductsRepository.GetById(id);
        if(product==null)
        {
            return null;
        }

        return new GetProductByIdDTO
        {
            ID=product.ID,
            Name=product.Name,
            Price=product.Price,
            Status=product.Status,
            Describtion=product.Describtion,
            AddingDate=product.AddingDate,
            CategoryID=product.CategoryID,
            ConditionID=product.ConditionID,
            ShopID=product.ShopID
        };
    }

    public GetAllProductDetailsByIdDTO? GetAllDetailsById(int? id)
    {
        var product=unitOfWork.ProductsRepository.GetAllDetailsById(id);
        if(product==null)
        {
            return null;
        }

        return new GetAllProductDetailsByIdDTO
        {
            ID=product.ID,
            Name=product.Name,
            Price=product.Price,
            Category=new GetPCategoryByIdDTO
            {
                ID=product.CategoryID,
                Name=product.Category!.Name
            },
            Status=product.Status,
            Describtion=product.Describtion,
            Condition=new GetPConditionByIdDTO
            {
                ID=product.ConditionID,
                Name=product.Condition!.Name
            },
            Images=product.Images.Select(img=>new GetAllProductImagesDTO
            {
                ID=img.ID,
                Name=img.Name,
                ProductID=img.ProductID
            }).ToList(),
            ShopID=product.ShopID
        };
    }

    public bool Add(AddProductDTO productDTO)
    {
        Product product=new Product
        {
            Name=productDTO.Name,
            Price=productDTO.Price,
            Describtion=productDTO.Describtion,
            AddingDate=DateTime.Now.ToString("dddd, dd MMMM yyyy h:mm tt"),
            CategoryID=productDTO.CategoryID,
            ConditionID=productDTO.ConditionID,
            ShopID=productDTO.ShopID
        };

        unitOfWork.ProductsRepository.Add(product);
        unitOfWork.SaveChanges();
        return true;
    }

    public bool Update(UpdateProductDTO productDTO)
    {
        var product=unitOfWork.ProductsRepository.GetById(productDTO.ID);
        if(product==null)
        {
            return false;
        }
        product.Name=productDTO.Name;
        product.Price=productDTO.Price;
        product.Describtion=productDTO.Describtion;
        product.CategoryID=productDTO.CategoryID;
        product.ConditionID=productDTO.ConditionID;
        product.Status=string.Empty;
 
        unitOfWork.ProductsRepository.Update(product);
        unitOfWork.SaveChanges();
        return true;
        
    }

    public bool Delete(int id)
    {
        var product=unitOfWork.ProductsRepository.GetById(id);
        if(product==null)
        {
            return false;
        }
        unitOfWork.ProductsRepository.DeleteById(id);
        unitOfWork.SaveChanges();
        return true;
    }

    public bool VerifyField(int value)
    {
        if(value==0)
        {
            return false;
        }

        return true;
    }

    public void EditStatus(int id, string status)
    {
        var product = unitOfWork.ProductsRepository.GetById(id);
        if (product != null)
        {
            product.Status = status;
            unitOfWork.ProductsRepository.Update(product);
            unitOfWork.SaveChanges();
        }

    }


}

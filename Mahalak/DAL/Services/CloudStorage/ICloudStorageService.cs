namespace Mahalak;
public interface ICloudStorageService
{
  Task<List<string>> Upload(List<IFormFile> files);

  Task Delete(string fileName);
}

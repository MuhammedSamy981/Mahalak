using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Mahalak;

public class CloudStorageService : ICloudStorageService
{
  private readonly Cloudinary cloudinary;

  public CloudStorageService(IConfiguration config)
  {
    cloudinary = new Cloudinary(
      new Account(
        _config["Cloudinary:Cloud"],
        _config["Cloudinary:ApiKey"],
        _config["Cloudinary:ApiSecret"])
      );
    cloudinary.Api.Secure = true;
  }  
    public async Task<List<string>> Upload(List<IFormFile> files)
  {
    List<string> imageNames = new List<string>();
    foreach (var file in files)
    {
      using var stream = file.OpenReadStream();
      ImageUploadParams imageUploadParams = new ImageUploadParams();
      imageUploadParams.File = new FileDescription(file.FileName, stream);
      imageUploadParams.Transformation = new Transformation().Width(700).Height(450).Crop("scale").Chain().Quality(35).Chain().FetchFormat("auto");
      ImageUploadResult imageUploadResult = await this.cloudinary.UploadAsync(imageUploadParams, new CancellationToken?());
      string[] strArray = imageUploadResult.Error == null ? imageUploadResult.SecureUrl.ToString().Split('/') : throw new Exception("Cloudinary error occured: " + imageUploadResult.Error.Message);
      imageNames.Add($"{strArray[strArray.Length - 2]}/{strArray[strArray.Length - 1]}");
    }
    List<string> stringList = imageNames;
    return stringList;
  }

  public async Task Delete(string fileName)
  {
    string str = fileName.Substring(fileName.IndexOf('/') + 1, fileName.IndexOf('.') - fileName.IndexOf('/') - 1);
    Console.WriteLine($"\n\n{str}\n\n");
    DelResResult delResResult = await this.cloudinary.DeleteResourcesAsync(new DelResParams()
    {
      PublicIds = new List<string>() { str },
      Type = "upload",
      ResourceType = 0
    }, new CancellationToken?());
    if (delResResult.Error != null)
      throw new Exception("Cloudinary error occured: " + delResResult.Error.Message);
  }
}

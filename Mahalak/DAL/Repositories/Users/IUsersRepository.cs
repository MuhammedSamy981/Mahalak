namespace Mahalak;
public interface IUsersRepository:IGenericRepository<User>
{
   List<User> GetAllByRole(string role);
   List<User> GetAllPaginatedByEmailOrPhone(string emailOrPhoneNumber);
   User? GetLogin(string emailOrPhoneNumber,string Password);
   User? GetByEmail(string Email);
   Guid GetIdByName(string name);
   User? GetById(Guid? id);
   public string? GetForgottenPassword(string emailOrPhoneNumber);
    void DeleteById(Guid id);
}
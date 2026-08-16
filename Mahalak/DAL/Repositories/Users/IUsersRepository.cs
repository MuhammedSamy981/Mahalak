namespace Mahalak;
public interface IUsersRepository : IGenericRepository<User>
{
  Task<List<User>> GetPaginatedByRoleAsync(int pageNumber,int pageSize,string roleName, CancellationToken ct);
  Task<int> GetCountByRoleAsync(string roleName, CancellationToken ct);
  Task<List<User>> GetSearchResultPaginatedAsync(int pageNumber,int pageSize,string roleName,string emailOrPhoneNumber, CancellationToken ct);
  Task<int> GetSearchResultCountAsync(string roleName,string emailOrPhoneNumber, CancellationToken ct);
  Task<bool> IsExistedAsync(string email);
  //IQueryable<User> GetAllInactive();
}
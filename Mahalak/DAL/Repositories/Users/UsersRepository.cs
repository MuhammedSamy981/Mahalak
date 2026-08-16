using Microsoft.EntityFrameworkCore;

namespace Mahalak;

public class UsersRepository : GenericRepository<User>,IUsersRepository
{
  private readonly MahalakDbContext mahalakDbContext;

  public UsersRepository(MahalakDbContext mahalakDbContext): base(mahalakDbContext)
  {
    this.mahalakDbContext = mahalakDbContext;
  }

  public async Task<List<User>> GetPaginatedByRoleAsync(int pageNumber, int pageSize, string roleName, CancellationToken ct)
  {
    return await GetAllByRoleAsync(roleName).Skip((pageNumber - 1) * pageSize)
        .Take(pageSize).ToListAsync(ct);
  }

  public async Task<int> GetCountByRoleAsync(string roleName, CancellationToken ct)
  {
   // Console.WriteLine("\n\n count"+await GetAllByRoleAsync(roleName,ct).CountAsync()+"---"+roleName+"\n\n");
    return await GetAllByRoleAsync(roleName).CountAsync(ct);
  }


  public async Task<List<User>> GetSearchResultPaginatedAsync(int pageNumber, int pageSize, string roleName, string emailOrPhoneNumber, CancellationToken ct)
  {
    return await GetAllSearchResultAsync(roleName, emailOrPhoneNumber).Skip((pageNumber - 1) * pageSize)
        .Take(pageSize).ToListAsync(ct);
  }

  public async Task<int> GetSearchResultCountAsync(string roleName, string emailOrPhoneNumber, CancellationToken ct)
  {
    return await GetAllSearchResultAsync(roleName, emailOrPhoneNumber).CountAsync(ct);
  }

  private IQueryable<User> GetAllByRoleAsync(string roleName)
  {
    var userIds = GetAllIdsAsync(roleName);
    return mahalakDbContext.Set<User>().AsNoTracking().Where(u => u.Id != null && userIds.Contains(u.Id))
    .OrderBy(u => u.Id);
  }

  private IQueryable<User> GetAllSearchResultAsync(string roleName, string emailOrPhoneNumber)
  {
    var userIds = GetAllIdsAsync(roleName);
    return mahalakDbContext.Set<User>().AsNoTracking().Where(u => u.Id != null && userIds.Contains(u.Id)
    && (u.Email!.Contains(emailOrPhoneNumber) || u.PhoneNumber!.Contains(emailOrPhoneNumber)))
    .OrderBy(u => u.Id);
  }

  private List<string> GetAllIdsAsync(string roleName)
  {
    var roleId = mahalakDbContext.Roles.AsNoTracking().Where(r => r.Name == roleName).Select(r => r.Id).FirstOrDefault();
    return mahalakDbContext.UserRoles.AsNoTracking().Where(ur => ur.RoleId == roleId).Select(ur => ur.UserId).ToList();
  }


  public async Task<bool> IsExistedAsync(string email)
  {
    return await mahalakDbContext.Set<User>().AsNoTracking().AnyAsync(u=>u.Email==email);
  }

 /* public IQueryable<User> GetAllInactive()
    {
      return  mahalakDbContext.Users.Where(u=>u.ViolationsCount == 0 && Convert.ToDateTime(u.LoginTime).AddYears(1) <= DateTime.Now);
    }*/

}
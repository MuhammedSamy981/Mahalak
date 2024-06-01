using Microsoft.EntityFrameworkCore;

namespace Mahalak;
public class UsersRepository : GenericRepository<User>,IUsersRepository
{
    private readonly MahalakContext mahalakContext;
    public UsersRepository(MahalakContext mahalakContext) : base(mahalakContext)
    {
        this.mahalakContext=mahalakContext;
    }

    public List<User> GetAllByRole(string role)
    {
        return mahalakContext.Set<User>().Where(r=>r.Role==role)
        .OrderByDescending(u=>u.ID).ToList();
    }

    public List<User> GetAllPaginatedByEmailOrPhone(string emailOrPhoneNumber)
    {
        return mahalakContext.Set<User>().Where(u =>u.Role=="User" &&
         (u.Email.Contains(emailOrPhoneNumber) || u.Phone.Contains(emailOrPhoneNumber))).ToList();
    }

    public Guid GetIdByName(string name)
    {
        return mahalakContext.Set<User>().FirstOrDefault(u=>u.Name==name)!.ID;
    }

    public User? GetLogin(string emailOrPhoneNumber,string Password)
    {
        return mahalakContext.Set<User>()
        .FirstOrDefault(u=>(u.Email==emailOrPhoneNumber||u.Phone==emailOrPhoneNumber)
        && u.Password==Password);
    }
    public string? GetForgottenPassword(string emailOrPhoneNumber)
    {
        return mahalakContext.Set<User>()
        .FirstOrDefault(u=>u.Email==emailOrPhoneNumber||u.Phone==emailOrPhoneNumber)!.Password;
    }

    public User? GetByEmail(string Email)
    {
        return mahalakContext.Set<User>().FirstOrDefault(u=>u.Email==Email);
    }

    public User? GetById(Guid? id)
    {
        return mahalakContext.Set<User>().Include(u=>u.Shops).FirstOrDefault(u=>u.ID==id);
    }

    public void DeleteById(Guid id)
    {
        var user = mahalakContext.Set<User>().Find(id);
        if (user != null)
        {
            mahalakContext.Set<User>().Remove(user);
        }
    }
}
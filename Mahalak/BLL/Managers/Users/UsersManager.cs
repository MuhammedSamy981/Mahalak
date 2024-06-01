
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace Mahalak;
public class UsersManager : IUsersManager
{
    private readonly IUnitOfWork unitOfWork;

    public UsersManager(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public List<GetAllPaginatedUsersDTO> GetAllPaginated(int pageSize, int pageNumber)
    {
        var users = unitOfWork.UsersRepository.GetAll();

        int listEnd = pageSize * pageNumber;
        int listStart = listEnd - pageSize;
        if (pageSize > users.Count - listStart)
        {
            pageSize = users.Count - listStart;
        }
        return users.Select(u => new GetAllPaginatedUsersDTO
        {
            ID = u.ID,
            Name = u.Name,
            Gender = u.Gender,
            Birthdate = u.Birthdate,
            Phone = u.Phone,
            Email = u.Email,
            Role = u.Role,
            MaxShopNum = u.MaxShopNum,
            AddedShopsExpDate = u.AddedShopsExpDate,
            LoginTime = u.LoginTime,
            Status = u.Status,
            ViolationsCount = u.ViolationsCount,
            UsersCount = users.Count

        }).ToList();
    }
    public List<GetAllPaginatedUsersByRoleDTO> GetAllPaginatedByRole(string role, int pageSize, int pageNumber)
    {
        var users = unitOfWork.UsersRepository.GetAllByRole(role);
        int listEnd = pageSize * pageNumber;
        int listStart = listEnd - pageSize;
        if (pageSize > users.Count - listStart)
        {
            pageSize = users.Count - listStart;
        }
        return users.Select(u => new GetAllPaginatedUsersByRoleDTO
        {
            ID = u.ID,
            Name = u.Name,
            Gender = u.Gender,
            Birthdate = u.Birthdate,
            Phone = u.Phone,
            Email = u.Email,
            Role = u.Role,
            MaxShopNum = u.MaxShopNum,
            AddedShopsExpDate = u.AddedShopsExpDate,
            LoginTime = u.LoginTime,
            Status = u.Status,
            ViolationsCount = u.ViolationsCount,
            UsersCount = users.Count
        }).ToList().GetRange(listStart, pageSize);
    }
    public List<GetAllPaginatedUsersByEmailOrPhoneDTO> GetAllPaginatedByEmailOrPhone(string emailOrPhoneNumber,
    int pageSize, int pageNumber)
    {
        var users = unitOfWork.UsersRepository.GetAllPaginatedByEmailOrPhone(emailOrPhoneNumber);
        int listEnd = pageSize * pageNumber;
        int listStart = listEnd - pageSize;
        if (pageSize > users.Count - listStart)
        {
            pageSize = users.Count - listStart;
        }
        Console.WriteLine("\n\n" + users.Count + "\n\n" + listStart + "\n\n" + listEnd + "\n\n");
        return users.Select(u => new GetAllPaginatedUsersByEmailOrPhoneDTO
        {
            ID = u.ID,
            Name = u.Name,
            Gender = u.Gender,
            Birthdate = u.Birthdate,
            Phone = u.Phone,
            Email = u.Email,
            Role = u.Role,
            MaxShopNum = u.MaxShopNum,
            AddedShopsExpDate = u.AddedShopsExpDate,
            LoginTime = u.LoginTime,
            Status = u.Status,
            ViolationsCount = u.ViolationsCount,
            UsersCount = users.Count

        }).ToList().GetRange(listStart, pageSize);
    }
    public GetUserByIdDTO? GetById(Guid? id)
    {
        var user = unitOfWork.UsersRepository.GetById(id);
        if (user == null)
        {
            return null;
        }

        return new GetUserByIdDTO
        {
            ID = user.ID,
            Name = user.Name,
            Password = user.Password,
            Gender = user.Gender,
            Birthdate = user.Birthdate,
            Phone = user.Phone,
            Email = user.Email,
            Role = user.Role,
            ShopsCount = user.Shops.Count,
            MaxShopNum = user.MaxShopNum,
            LoginTime = user.LoginTime
        };
    }

    public GetUserLoginDTO? GetLogin(string emailOrPhoneNumber, string Password)
    {
        var user = unitOfWork.UsersRepository.GetLogin(emailOrPhoneNumber, Password);
        if (user != null)
        {
            user.LoginTime = DateTime.Now.ToString("dddd, dd MMMM yyyy h:mm tt");
            unitOfWork.UsersRepository.Update(user);
            unitOfWork.SaveChanges();

            Claim C1 = new Claim(ClaimTypes.Name, user.Name);
            Claim C2 = new Claim(ClaimTypes.Email, user.Email);
            Claim C3 = new Claim(ClaimTypes.MobilePhone, user.Phone);
            Claim C4 = new Claim(ClaimTypes.Role, user.Role);

            ClaimsIdentity CI = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            CI.AddClaim(C1);
            CI.AddClaim(C2);
            CI.AddClaim(C3);
            CI.AddClaim(C4);

            ClaimsPrincipal CP = new ClaimsPrincipal();
            CP.AddIdentity(CI);

            return new GetUserLoginDTO
            {
                Status = user.Status,
                ViolationsCount = user.ViolationsCount,
                ExpDtOfBan = user.ExpDtOfBan,
                CP = CP
            };

        }
        return null;
    }


    public void Add(AddUserDTO userDTO)
    {
        User user = new User
        {
            Name = userDTO.Name,
            Password = userDTO.Password,
            Email = userDTO.Email,
            Phone = userDTO.Phone,
            Gender = userDTO.Gender,
            Birthdate = userDTO.Birthdate,
        };

        unitOfWork.UsersRepository.Add(user);
        unitOfWork.SaveChanges();
    }
    public bool Update(UpdateUserDTO userDTO)
    {
        var user = unitOfWork.UsersRepository.GetById(userDTO.ID);
        if (user == null)
        {
            return false;
        }

        user.Name = userDTO.Name;
        user.Password = userDTO.Password;
        user.Gender = userDTO.Gender;
        user.Birthdate = userDTO.Birthdate;
        user.Phone = userDTO.Phone;
        user.Email = userDTO.Email;

        unitOfWork.UsersRepository.Update(user);
        unitOfWork.SaveChanges();
        return true;

    }

    public async Task EditStatus(Guid id, bool status)
    {
        var user = unitOfWork.UsersRepository.GetById(id);
        if (user != null)
        {
            user.Status = status;
            unitOfWork.UsersRepository.Update(user);
            await unitOfWork.SaveChangesAsync();
        }

    }
    public void EditRole(Guid id, string role)
    {
        var user = unitOfWork.UsersRepository.GetById(id);
        if (user != null)
        {
            user.Role = role;
            unitOfWork.UsersRepository.Update(user);
            unitOfWork.SaveChanges();
        }

    }
    public void EditClientCommentStatus(int id, string status)
    {
        var rating = unitOfWork.RatingsRepository.GetById(id);
        if (rating != null)
        {
            if (status.Trim() == "مرفوض")
            {
                rating.Comment = "تم حذف هذا التعليق لأنه يحتوى على أساءة";
                var user = unitOfWork.UsersRepository.GetById(rating.UserID);
                if (user != null)
                {
                    user.ViolationsCount += 1;
                    user.ExpDtOfBan = DateTime.Now.AddDays(user.ViolationsCount)
                    .ToString("dddd, dd MMMM yyyy h:mm tt");
                    unitOfWork.UsersRepository.Update(user!);
                    unitOfWork.SaveChanges();
                }
            }
            rating.Status = status;
            unitOfWork.RatingsRepository.Update(rating);
            unitOfWork.SaveChanges();
        }

    }



    public bool VerifyField(string value, string type)
    {
        var users = unitOfWork.UsersRepository.GetAll();

        for (int i = 0; i < users.Count; i++)
        {
            if (type == "Name")
            {
                if (users[i].Name == value.Trim())
                {
                    return false;
                }

            }

            if (type == "Email")
            {
                if (users[i].Email == value.Trim())
                {
                    return false;
                }

            }

            if (type == "Phone")
            {
                if (users[i].Phone == value.Trim())
                {
                    return false;
                }

            }

        }
        return true;
    }

    public bool VerifyEditField(string value, string type, Guid? id)
    {
        Console.WriteLine(id);
        var users = unitOfWork.UsersRepository.GetAll();
        var userToEdit = unitOfWork.UsersRepository.GetById(id);
        if (userToEdit != null)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (type == "Name" && userToEdit.Name != value)
                {
                    if (users[i].Name == value.Trim())
                    {
                        return false;
                    }

                }

                if (type == "Email" && userToEdit.Email != value)
                {
                    if (users[i].Email == value.Trim())
                    {
                        return false;
                    }

                }

                if (type == "Phone" && userToEdit.Phone != value)
                {
                    if (users[i].Phone == value.Trim())
                    {
                        return false;
                    }
                }

            }
        }
        return true;
    }

    public bool Delete(Guid id)
    {
        var user = unitOfWork.UsersRepository.GetById(id);
        if (user == null)
        {
            return false;
        }

        unitOfWork.UsersRepository.DeleteById(id);
        unitOfWork.SaveChanges();
        return true;
    }

    public Guid GetIdByName(string name)
    {
        return unitOfWork.UsersRepository.GetIdByName(name);
    }

    public async Task<bool> ResetPassword(GetForgottenUserPasswordDTO forgottenUserPasswordDTO)
    {
        var user = unitOfWork.UsersRepository.GetByEmail(forgottenUserPasswordDTO.Email);
        if (user != null)
        {
            Mail mail = new Mail
            {
                UserName = user.Name,
                UserEmail = user.Email,
                UserPassword = user.Password,
                EmailSubject = "Reset Password",
                EmailBody = "مرحبا ," + user.Name + "كلمة المرور الخاصة بك هى : " + user.Password
            };
            await unitOfWork.MailService.Send(mail);
            return true;
        }
        return false;
    }

    public async Task<bool> CheckViolationsCount()
    {

        foreach (var user in unitOfWork.UsersRepository.GetAll())
        {
            if (user.ExpDtOfBan != string.Empty)
            {
                if (Convert.ToDateTime(user.ExpDtOfBan) <= DateTime.Now)
                {
                    await EditStatus(user.ID, false);
                }
                else
                {
                    await EditStatus(user.ID, true);
                }
            }
        }
        return true;
    }

    public  async Task EditAddingShops(Guid id, int shopsCount, int period)
    {
        var user = unitOfWork.UsersRepository.GetById(id);
        if (user != null)
        {
            user.MaxShopNum = shopsCount;
            if (period != 0)
            {
                user.AddedShopsExpDate = DateTime.Now.
                AddMonths(period).ToString("dddd, dd MMMM yyyy h:mm tt");
            }
            else
            {
                user.AddedShopsExpDate = string.Empty;
            }
            unitOfWork.UsersRepository.Update(user);
           await unitOfWork.SaveChangesAsync();
        }

    }

    public async Task<bool> CheckAddingShopsPeriod()
    {

        foreach (var user in unitOfWork.UsersRepository.GetAll())
        {
            if (user.AddedShopsExpDate != string.Empty)
            {
                if (Convert.ToDateTime(user.AddedShopsExpDate) <= DateTime.Now)
                {
                   await EditAddingShops(user.ID, 2, 0);
                }
            }
        }
        return true;
    }

    public string? GetForgottenPassword(string emailOrPhoneNumber)
    {
        return unitOfWork.UsersRepository.GetForgottenPassword(emailOrPhoneNumber);
    }


}
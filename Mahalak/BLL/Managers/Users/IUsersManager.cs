namespace Mahalak;
public interface IUsersManager
{
    List<GetAllPaginatedUsersDTO> GetAllPaginated(int pageSize, int pageNumber);
    List<GetAllPaginatedUsersByRoleDTO> GetAllPaginatedByRole(string role, int pageSize, int pageNumber);
    List<GetAllPaginatedUsersByEmailOrPhoneDTO> GetAllPaginatedByEmailOrPhone(string emailOrPhoneNumber,
    int pageSize, int pageNumber);
    GetUserByIdDTO? GetById(Guid? id);
    Guid GetIdByName(string name);
    Task<bool> ResetPassword(GetForgottenUserPasswordDTO forgottenUserPasswordDTO);
    GetUserLoginDTO? GetLogin(string emailOrPhoneNumber, string Password);
    bool VerifyField(string value, string type);
    bool VerifyEditField(string value, string type, Guid? id);
    void Add(AddUserDTO userDTO);
    bool Update(UpdateUserDTO userDTO);
    bool Delete(Guid id);
    Task EditStatus(Guid id, bool status);
    void EditRole(Guid id, string role);
    void EditClientCommentStatus(int id, string status);
    Task<bool> CheckViolationsCount();
    Task EditAddingShops(Guid id, int shopsCount, int period);
    Task<bool> CheckAddingShopsPeriod();
    public string? GetForgottenPassword(string emailOrPhoneNumber);

}
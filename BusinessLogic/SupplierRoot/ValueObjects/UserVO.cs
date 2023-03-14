
namespace BusinessLogic.SupplierRoot.ValueObjects
{
    public class UserVO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }


        public UserVO(int id,string name, string email, string contactNo, int roleId, bool isActive)
        {
            Id = id;
            Name = name;
            Email = email;
            ContactNo = contactNo;
            RoleId = roleId;
            IsActive = isActive;
        }

    }
}

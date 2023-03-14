using System.ComponentModel.DataAnnotations;

namespace Services.DTOs
{
    public class UserDto
    {
        public int? Id { get; set; }

        [RegularExpression("(^[A-Za-z]{2,}[ ]{0,1}[A-Za-z]{2,}$)", ErrorMessage = "Name should be characters with allowed only 1 space and minimum length is 2 !!")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Please enter valid Email-ID !!")]
        public string Email { get; set; }

        [RegularExpression("^[+]{1}(?:[0-9\\-\\(\\)\\/\\.]\\s?){6,15}[0-9]{1}$",ErrorMessage = "Please enter valid ContactNumber !!")]
        public string ContactNo { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }

        public UserDto(int? id, string name, string email, string contactNo, int roleId, bool isActive)
        {
            Id = id;
            Name = name;
            Email = email.ToLower();
            ContactNo = contactNo;
            RoleId = roleId;
            IsActive = isActive;
        }
    }
}

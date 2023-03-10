using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }

        public UserDto(int? id, string name, string email, string contactNo, int roleId, bool isActive)
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

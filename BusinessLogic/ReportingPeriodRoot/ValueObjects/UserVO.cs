using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReportingPeriodRoot.ValueObjects
{
    public class UserVO
    {
        public int UserId { get; private set; }
        public string UserName { get; private set; }

        public string Email { get; private set; }

        public string ContactNo { get; private set; }

        public int RoleId { get; private set; }

        public bool Active { get; private set; }


        public UserVO() { }

        public UserVO(int userId, string userName,string email,string contactNo,int roleId,bool active)
        {
            UserId= userId;
            UserName= userName;
            Email= email;
            ContactNo= contactNo;
            RoleId= roleId;
            Active= active;
        }

        
    }
}

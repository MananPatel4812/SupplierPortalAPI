using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.SupplierRoot.DomainModels
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }

        public User()
        {

        }

        public User(string name, string email, string contactNo, int roleId, bool isActive)
        {
            Name = name;
            Email = email;
            ContactNo = contactNo;
            RoleId = roleId;
            IsActive = isActive;
        }

        public User(int id,string name,string email,string contactNo,int roleId,bool isActive) : this(name,email,contactNo,roleId,isActive)
        {
            Id = id;
        }
/*
        public User AddUser(User user)
        {
            //add User
            var users = new User(user.Id, user.Name, user.Email, user.ContactNo, user.RoleId, user.IsActive);
            
            return users;
        }*/

    }
}

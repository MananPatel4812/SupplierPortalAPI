using DataAccess.DataActionContext;
using DataAccess.DataActions.Interfaces;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataActions
{
    public class UserDataActionManager : IUserPersister
    {
        private readonly SupplierPortalDBContext _context;

        public UserDataActionManager(SupplierPortalDBContext context)
        {
            _context = context;
        }

        public int AddUser(UserEntity userEntity)
        {
            userEntity.CreatedOn = DateTime.UtcNow;
            userEntity.CreatedBy = "System";
            _context.UserEntities.Add(userEntity);
            _context.SaveChanges();
            return userEntity.Id;

        }

        protected void Dispose(bool disposing)
        {
            if(disposing) 
            {
                if(_context != null ) 
                {
                    _context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int UpdateUser(UserEntity userEntity)
        {
            var entity = _context.UserEntities.FirstOrDefault(x => x.Id == userEntity.Id);

            entity.Name = userEntity.Name;
            entity.Email = userEntity.Email;
            entity.ContactNo = userEntity.ContactNo;
            entity.RoleId = entity.RoleId;
            entity.IsActive= userEntity.IsActive;
            entity.UpdatedOn = DateTime.UtcNow;
            entity.UpdatedBy = "System";
           
            _context.UserEntities.Update(entity);
            _context.SaveChanges();
            return userEntity.Id;
        }

        public UserEntity GetUserById(int userId)
        {
            var user = _context.UserEntities.Where(x => x.Id == userId).FirstOrDefault();

            if (user == null)
                throw new Exception("User not found !");
            
            return user;
        }
    }
}

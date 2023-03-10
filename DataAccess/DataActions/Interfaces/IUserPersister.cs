using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataActions.Interfaces
{
    public interface IUserPersister: IDisposable
    {
        int AddUser(UserEntity userEntity);
        int UpdateUser(UserEntity userEntity);
        UserEntity GetUserById (int userId);
    }
}

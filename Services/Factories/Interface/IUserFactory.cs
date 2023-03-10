using BusinessLogic.SupplierRoot.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Factories.Interface
{
    public interface IUserFactory
    {
        User CreateNewUser(string name, string email, string contactNo, int roleId, bool isActive);
    }
}

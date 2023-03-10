using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.SupplierRoot.DomainModels
{

    public class Contact
    {
        public int Id { get; private set; }
        public int SupplierId { get; private set; }
        public int UserId { get; private set; }


        internal Contact()
        { }

        internal Contact(int supplierId, int userId)
        {
            SupplierId = supplierId;
            UserId = userId;
        }

        internal Contact(int id, int supplierId, int userId) : this(supplierId, userId)
        {
            Id = id;
        }
    }
}

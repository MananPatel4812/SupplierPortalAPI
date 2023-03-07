using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.SupplierRoot.DomainModels
{
    public class Contact
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int UserId { get; set; }

        public Contact()
        {  }

        public Contact(int supplierId, int userId)
        {
            SupplierId = supplierId;
            UserId = userId;
        }

        public Contact(int id, int supplierId, int userId): this(supplierId, userId)
        {
            Id = id;
        }
    }
}

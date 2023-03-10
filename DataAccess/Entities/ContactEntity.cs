using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class ContactEntity
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int UserId { get; set; }

        public virtual SupplierEntity Supplier { get; set; } = null!;
        public virtual UserEntity User { get; set; } = null!;
    }
}

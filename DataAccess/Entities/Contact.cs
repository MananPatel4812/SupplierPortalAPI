using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Contact
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int UserId { get; set; }

        public virtual Supplier Supplier { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}

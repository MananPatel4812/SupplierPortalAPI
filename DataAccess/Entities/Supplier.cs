using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Supplier
    {
        public Supplier()
        {
            Contacts = new HashSet<Contact>();
            ReportingPeriodSuppliers = new HashSet<ReportingPeriodSupplier>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Alias { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ContactNo { get; set; } = null!;
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<ReportingPeriodSupplier> ReportingPeriodSuppliers { get; set; }
    }
}

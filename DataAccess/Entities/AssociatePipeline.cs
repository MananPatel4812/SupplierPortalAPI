using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class AssociatePipeline
    {
        public AssociatePipeline()
        {
            Facilities = new HashSet<Facility>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }

        public virtual ICollection<Facility> Facilities { get; set; }
    }
}

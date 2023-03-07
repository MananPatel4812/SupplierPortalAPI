using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class SupplyChainStage
    {
        public SupplyChainStage()
        {
            Facilities = new HashSet<Facility>();
            FacilityRequiredDocumentTypes = new HashSet<FacilityRequiredDocumentType>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<Facility> Facilities { get; set; }
        public virtual ICollection<FacilityRequiredDocumentType> FacilityRequiredDocumentTypes { get; set; }
    }
}

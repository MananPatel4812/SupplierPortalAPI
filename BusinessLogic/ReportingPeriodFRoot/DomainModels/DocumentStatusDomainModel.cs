using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReportingPeriodFRoot.DomainModels
{
    public class DocumentStatusDomainModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Active { get; set; }

        public DocumentStatusDomainModel(int id,string name,string description,bool active)
        {
            Id = id;
            Name = name;
            Description = description;
            Active = active;
        }
    }
}

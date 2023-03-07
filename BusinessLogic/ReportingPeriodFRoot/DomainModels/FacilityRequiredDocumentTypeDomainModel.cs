using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReportingPeriodFRoot.DomainModels
{
    public class FacilityRequiredDocumentTypeDomainModel
    {
        public int Id { get; set; }
        public int ReportingTypeId { get; set; }
        public int SupplyChainStageId { get; set; }
        public int DocumentTypeId { get; set; }
        public int DocumentRequiredStatusId { get; set; }

        public FacilityRequiredDocumentTypeDomainModel(int id,int reportingTypeId,int supplyChainStageId,int documentTypeId,int documentRequiredStatusId)
        {
            Id = id;
            ReportingTypeId = reportingTypeId;
            SupplyChainStageId = supplyChainStageId;
            DocumentTypeId = documentTypeId;
            DocumentRequiredStatusId = documentRequiredStatusId;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReportingPeriodRoot.ValueObjects;

public class SupplierVO
{
	public SupplierVO(int id,string name,bool active,IEnumerable<FacilityVO> facilities)
	{
		SupplierId=id;
		SupplierName = name;
		Active = active;
        Facilities = facilities;
	}

	public int SupplierId { get; set;}

	public string SupplierName { get; set;}

	public bool Active { get; set;}

	public IEnumerable<FacilityVO> Facilities { get; set;}
}

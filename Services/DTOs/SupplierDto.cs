using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs;

public class SupplierDto
{
    public int? SupplierId { get; set; }
    public string SupplierName { get; set; }
    public string? Alias { get; set; }
    public string? Email { get; set; }
    public string ContactNo { get; set; }
    public bool IsActive { get; set; }

    public IEnumerable<FacilityDto>? Facilities;
    public IEnumerable<ContactDto>? Contacts;

    public SupplierDto(int? id, string name, string? alias, string? email, string contactNo, bool active, IEnumerable<FacilityDto>? facilities, IEnumerable<ContactDto>? contacts)
    {
        SupplierId = id;
        SupplierName = name;
        Alias = alias;
        Email = email;
        ContactNo = contactNo;
        IsActive = active;
        Facilities = facilities;
        Contacts = contacts;
    }
};

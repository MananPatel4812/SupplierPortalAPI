using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs;

public class SupplierDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Alias { get; set; }
    public string Email { get; set; }
    public string ContactNo { get; set; }
    public bool Active { get; set; }

    public IEnumerable<FacilityDto> Facilities;
    public IEnumerable<ContactDto> Contacts;

    public SupplierDto(int id, string name, string alias, string email, string contactNo, bool active, IEnumerable<FacilityDto> facilities, IEnumerable<ContactDto> contacts)
    {
        Id = id;
        Name = name;
        Alias = alias;
        Email = email;
        ContactNo = contactNo;
        Active = active;
        Facilities = facilities;
        Contacts = contacts;
    }
};

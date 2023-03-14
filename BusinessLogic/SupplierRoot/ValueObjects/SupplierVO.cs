﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.SupplierRoot.ValueObjects;

public class SupplierVO
{
    public SupplierVO(int id, string name, bool active, IEnumerable<FacilityVO> facilities)
    {
        Id = id;
        Name = name;
        Active = active;
        Facilities = facilities;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public bool Active { get; set; }

    public IEnumerable<FacilityVO> Facilities { get; set; }
}

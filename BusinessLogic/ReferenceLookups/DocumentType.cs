﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReferenceLookups
{
    public class DocumentType : ReferenceLookup
    {
        public DocumentType() { }

        public DocumentType(int value, string displayName) : base(value, displayName) { }
    }
}

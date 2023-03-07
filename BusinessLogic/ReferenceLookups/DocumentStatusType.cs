using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReferenceLookups
{
    public class DocumentStatusType : ReferenceLookup
    {
        public DocumentStatusType() { }

        public DocumentStatusType(int value, string displayname) : base(value, displayname) { }
    }
}

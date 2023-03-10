using BusinessLogic.ReferenceLookups;
using BusinessLogic.ReportingPeriodRoot.ValueObjects;
using BusinessLogic.SupplierRoot.Interfaces;

namespace BusinessLogic.SupplierRoot.DomainModels
{
    public class Supplier : ISupplier
    {
        //
        private HashSet<Contact> Contacts;
        private HashSet<Facility> Facilities;

        public Supplier(string name, string alias, string email,
            string contactno, bool active)
        {
            Name = name;
            Alias = alias;
            Email = email;
            ContactNo = contactno;
            Active = active;

            Facilities = new HashSet<Facility>();
            Contacts = new HashSet<Contact>();

        }

        public Supplier(int id, string name, string alias, string email,
            string contactno, bool active) : this(name, alias, email, contactno, active)
        {
            Id = id;
        }

        public Supplier() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Alias { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public bool Active { get; set; }

        public IEnumerable<Facility> Facility
        {
            get
            {
                if(Facilities == null)
                {
                    return new List<Facility>();
                }
                return Facilities.ToList();
            }
        }

        public IEnumerable<Contact> Contact
        {
            get
            {
                if (Contacts == null)
                {
                    return new List<Contact>();
                }
                return Contacts.ToList();
            }
        }

        public Contact UpdateSupplierContact(int Id, Supplier Supplier, UserVO userVO)
        {
            throw new NotImplementedException();
        }

        public Contact AddSupplierContact(int Id, Supplier Supplier, UserVO userVO)
        {
            throw new NotImplementedException();
        }

        public Facility AddSupplierFacility(int Id, string name, string description, bool isPrimary, AssociatePipeline AssociatePipeline, ReportingType ReportingType, SupplyChainStage SupplyChainStage)
        {
            throw new NotImplementedException();
        }

        public Facility UpdateSupplierFacility(int Id, string name, string description, bool isPrimary, AssociatePipeline AssociatePipeline,ReportingType ReportingType,SupplyChainStage SupplyChainStage)
        {
            throw new NotImplementedException();
        }
    }
}

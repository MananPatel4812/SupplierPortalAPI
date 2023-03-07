using BusinessLogic.SupplierRoot.Interfaces;
using DataAccess.Entities;

namespace BusinessLogic.SupplierRoot.DomainModels
{
    public class Supplier //: ISupplier
    {
        /*private HashSet<Contact> Contacts;
        private HashSet<Facility> Facilities;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public Supplier(string name, string alias, string email, 
            string contactno, bool active)
        {
            Name = name;
            Alias = alias;
            Email = email;
            ContactNo = contactno;
            Active = active;
            CreatedOn = DateTime.UtcNow;
            UpdatedOn = null;
            CreatedBy = "System";
            UpdatedBy = null;


            Facilities = new HashSet<Facility>();
            Contacts = new HashSet<Contact>();

        }

        public Supplier(int id,string name, string alias, string email,
            string contactno, bool active): this(name,alias,email,contactno,active)
        {
            Id = id;
        }

        public Supplier()  { }


        public IEnumerable<Facility> SupplierFacility
        {
            get {
                if(Facilities == null)
                {
                    return new List<Facility>();
                }
                return Facilities.ToList();
            }
        }

        public IEnumerable<Contact> SupplierContact
        {
            get
            {
                if(Contacts == null) 
                {
                    return new List<Contact>();
                }
                return Contacts.ToList();
            }
        }

        public Facility AddSupplierFacility(int Id, string name, string description, bool isPrimary, AssociatePipeline AssociatePipeline, ReportingType ReportingType, SupplyChainStage SupplyChainStage)
        {
            throw new NotImplementedException();
        }

        public Facility UpdateSupplierFacility(int Id, string name, string description, bool isPrimary, AssociatePipeline AssociatePipeline, ReportingType ReportingType, SupplyChainStage SupplyChainStage)
        {
            throw new NotImplementedException();
        }

        public Contact AddSupplierContact(int Id, DataAccess.Entities.Supplier Supplier, User User)
        {
            throw new NotImplementedException();
        }

        public Contact UpdateSupplierContact(int Id, DataAccess.Entities.Supplier Supplier, User User)
        {
            throw new NotImplementedException();
        }*/

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

        public IEnumerable<Facility> SupplierFacility => throw new NotImplementedException();
        public IEnumerable<Contact> SupplierContact => throw new NotImplementedException();

        public Contact AddSupplierContact(int Id, Supplier Supplier, User User)
        {
            throw new NotImplementedException();
        }

        public Facility AddSupplierFacility(int Id, string name, string description, bool isPrimary, AssociatePipeline AssociatePipeline, ReportingType ReportingType, SupplyChainStage SupplyChainStage)
        {
            throw new NotImplementedException();
        }

        public Contact UpdateSupplierContact(int Id, Supplier Supplier, User User)
        {
            throw new NotImplementedException();
        }

        public Facility UpdateSupplierFacility(int Id, string name, string description, bool isPrimary, AssociatePipeline AssociatePipeline, ReportingType ReportingType, SupplyChainStage SupplyChainStage)
        {
            throw new NotImplementedException();
        }
    }
}

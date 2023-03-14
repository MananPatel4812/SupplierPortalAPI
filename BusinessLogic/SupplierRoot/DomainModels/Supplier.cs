using BusinessLogic.ReferenceLookups;
using BusinessLogic.ReportingPeriodRoot.ValueObjects;
using BusinessLogic.SupplierRoot.Interfaces;

namespace BusinessLogic.SupplierRoot.DomainModels
{
    public class Supplier : ISupplier
    {
        //
        private HashSet<Contact> _contacts;
        private HashSet<Facility> _facilities;

        public Supplier(string name, string alias, string email,
            string contactno, bool isActive)
        {
            Name = name;
            Alias = alias;
            Email = email;
            ContactNo = contactno;
            IsActive = isActive;

            _facilities = new HashSet<Facility>();
            _contacts = new HashSet<Contact>();

        }

        public Supplier(int id, string name, string alias, string email,
            string contactno, bool isActive) : this(name, alias, email, contactno, isActive)
        {
            Id = id;
        }

        private Supplier() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public bool IsActive { get; set; }

        public IEnumerable<Facility> Facilities
        {
            get
            {
                if(_facilities == null)
                {
                    return new List<Facility>();
                }
                return _facilities.ToList();
            }
        }

        public IEnumerable<Contact> Contacts
        {
            get
            {
                if (_contacts == null)
                {
                    return new List<Contact>();
                }
                return _contacts.ToList();
            }
        }

       /* public Contact UpdateSupplierContact(int Id, Supplier Supplier,User user)
        {
            throw new NotImplementedException();
            *//*
             * 
             *//*
        }

        public Contact AddSupplierContact(int Id, Supplier Supplier, User user)
        {
            throw new NotImplementedException();

            *//*
             * 
             *//*
        }*/

        public Facility AddSupplierFacility(int Id, string name, string description, bool isPrimary, AssociatePipeline AssociatePipeline, ReportingType ReportingType, SupplyChainStage SupplyChainStage)
        {
            throw new NotImplementedException();

            /*
             * 
             */
        }

        public Facility UpdateSupplierFacility(int Id, string name, string description, bool isPrimary, AssociatePipeline AssociatePipeline,ReportingType ReportingType,SupplyChainStage SupplyChainStage)
        {
            throw new NotImplementedException();
            /*
             * 
             */
        }
    }
}

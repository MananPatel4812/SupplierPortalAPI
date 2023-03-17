using BusinessLogic.ReferenceLookups;
using BusinessLogic.ReportingPeriodRoot.ValueObjects;
using BusinessLogic.SupplierRoot.Interfaces;
using BusinessLogic.SupplierRoot.ValueObjects;

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

        public void UpdateSupplier(string name, string alias, string email, string contactNo, bool isActive)
        {
            UpdateName(name);
            UpdateAlias(alias);
            UpdateEmail(email);
            UpdateContactNo(contactNo);
            UpdateIsActive(isActive);
        }

        private void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name is required");
            }
            else
                Name = name;

        }
        private void UpdateAlias(string alias)
        {
            Alias = alias;
        }


        private void UpdateEmail(string email)
        {
            Email = email;
        }

        private void UpdateContactNo(string contactNo)
        {
            ContactNo = contactNo;
        }

        private void UpdateIsActive(bool isActive)
        {
            IsActive = isActive;
        }


        /* public Contact UpdateSupplierContact(int Id, Supplier Supplier,User user)
         {
             throw new NotImplementedException();
         }*/

        public Contact AddSupplierContact(int Id, Supplier Supplier, UserVO userVO)
         {
             //check isContact exist or not
             var IsExists = _contacts.Any(x => x.UserVO.Id == userVO.Id);
             
            if(IsExists == true)
            {
                throw new Exception("Contact is already exists with Supplier !!");
            }
            else
            {
                var contact = new Contact(Id, Supplier.Id, userVO);
                _contacts.Add(contact);

                return contact;
            }
            
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

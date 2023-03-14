

namespace Services.DTOs
{
    public class ContactDto
    {
        public int? Id { get; set; }
        public int SupplierId { get; set; }
        //public string SupplierName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        public ContactDto(int? id, int supplierId, int userId, string userName)
        {
            Id = id;
            SupplierId = supplierId;
            //SupplierName = supplierName;
            UserId = userId;
            UserName = userName;
        }
    }
}

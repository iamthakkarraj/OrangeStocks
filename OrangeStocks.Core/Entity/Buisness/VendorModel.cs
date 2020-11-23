using System;

namespace OrangeStocks.Core.Entity {

    public class VendorModel : OrangeStocksBuisnessModel{

        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public string References { get; set; }
        public string Other { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public UserModel User { get; set; }

    }

}
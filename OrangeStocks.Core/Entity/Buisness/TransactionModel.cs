using System;

namespace OrangeStocks.Core.Entity {

    public class TransactionModel : OrangeStocksBuisnessModel{

        public System.Guid Id { get; set; }
        public System.Guid InwardType { get; set; }
        public Nullable<System.Guid> VendorId { get; set; }
        public Nullable<System.Guid> CustomerId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

    }

}
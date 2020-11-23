using System;

namespace OrangeStocks.Core.Entity {

    public class TransactionDetailModel : OrangeStocksBuisnessModel{

        public System.Guid Id { get; set; }
        public System.Guid InwardId { get; set; }
        public System.Guid SockItemId { get; set; }
        public int Qunatity { get; set; }
        public decimal UnitPrice { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

    }

}
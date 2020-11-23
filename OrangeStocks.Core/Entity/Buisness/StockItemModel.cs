using System;

namespace OrangeStocks.Core.Entity {

    public class StockItemModel : OrangeStocksBuisnessModel{

        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public System.Guid Category { get; set; }
        public string Description { get; set; }
        public string HSNCode { get; set; }
        public decimal GST { get; set; }
        public System.Guid VendorId { get; set; }
        public decimal PreferredPrice { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

    }

}
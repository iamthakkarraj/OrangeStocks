using System;

namespace OrangeStocks.Core.Entity {

    public class UserModel : OrangeStocksBuisnessModel{

        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> Role { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

    }

}
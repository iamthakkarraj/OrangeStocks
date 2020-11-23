using OrangeStocks.Core.Entity;
using System;
using System.Collections.Generic;

namespace OrangeStocks.BLL.Interfaces {

    public interface IOrangeStocksCRUDService<B> where B : OrangeStocksBuisnessModel { 

        IEnumerable<B> Get();
        B Get(Guid id);
        bool Add(B entity);
        bool Update(B entity);
        bool Delete(Guid id);
        bool Save();

    }

}

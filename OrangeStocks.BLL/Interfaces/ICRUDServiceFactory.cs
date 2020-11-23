using OrangeStocks.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeStocks.BLL.Interfaces {

    public interface ICRUDServiceFactory<B> where B : OrangeStocksBuisnessModel {

        IOrangeStocksCRUDService<B> GetService();

    }

}

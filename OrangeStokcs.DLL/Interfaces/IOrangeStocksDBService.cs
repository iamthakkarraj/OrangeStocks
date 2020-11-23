using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeStocks.DLL.Interfaces {

    public interface IOrangeStocksDBService<T> where T : class {

        IEnumerable<T> Get();
        T Get(Guid id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(Guid id);
        bool Save();

    }

}

using OrangeStocks.BLL.Interfaces;
using OrangeStocks.Core.Entity;
using OrangeStocks.Core.Utility;
using OrangeStocks.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrangeStocks.BLL.Managers {

    public class OrangeStocksCRUDService<B, D> : IOrangeStocksCRUDService<B>
        where B : OrangeStocksBuisnessModel
        where D : class {

        private readonly IOrangeStocksDBService<D> _DBService;

        public OrangeStocksCRUDService(IOrangeStocksDBService<D> _DBService) { this._DBService = _DBService; }

        public IEnumerable<B> Get() {            
            List<B> destination = new List<B>();
            _DBService.Get().ToList().ForEach(delegate (D entity) { destination.Add(ModelMapperService.ManualMap<D, B>(entity)); });
            return destination;
        }

        public B Get(Guid id) { return ModelMapperService.ManualMap<D, B>(_DBService.Get(id)); }
        public bool Add(B entity) { return _DBService.Add(ModelMapperService.ManualMap<B, D>(entity)); }
        public bool Update(B entity) { return _DBService.Update(ModelMapperService.ManualMap<B, D>(entity)); }
        public bool Delete(Guid id) { return _DBService.Delete(id) && Save(); }
        public bool Save() { return _DBService.Save(); }
        
    }

}
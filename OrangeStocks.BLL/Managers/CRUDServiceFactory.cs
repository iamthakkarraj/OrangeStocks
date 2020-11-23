using OrangeStocks.BLL.Interfaces;
using OrangeStocks.Core.Entity;

namespace OrangeStocks.BLL.Managers {

    public class CRUDServiceFactory<B> : ICRUDServiceFactory<B> where B : OrangeStocksBuisnessModel {

        IOrangeStocksCRUDService<B> _CRUDService;

        public CRUDServiceFactory(IOrangeStocksCRUDService<B> _CRUDService) 
        { this._CRUDService = _CRUDService; }

        public IOrangeStocksCRUDService<B> GetService() { return this._CRUDService;}

    }

}

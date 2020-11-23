using OrangeStocks.API.Controller;
using OrangeStocks.BLL.Interfaces;
using OrangeStocks.Core.Entity;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrangeStocks.API.Controllers {

    public class StocksController : OrangeStocksBaseController {

        private readonly IOrangeStocksCRUDService<StockItemModel> _StockItemService;
        private readonly IOrangeStocksCRUDService<StockItemCategoryModel> _StockItemCategoryService;

        public StocksController(
                ICRUDServiceFactory<StockItemModel> _StockItemService,
                ICRUDServiceFactory<StockItemCategoryModel> _StockItemCategoryService) {                
            this._StockItemService = _StockItemService.GetService();                                    
            this._StockItemCategoryService = _StockItemCategoryService.GetService();
        }

        #region Stock Items
        // GET: api/StockItem
        [HttpGet, Route("Stocks/Item/")]
        public IHttpActionResult GetStockItems() {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _StockItemService.Get())));
        }

        // GET: api/StockItem/{GUID}
        [HttpGet, Route("Stocks/Item/{id}")]
        public IHttpActionResult GetStockItem(Guid id) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _StockItemService.Get(id))));
        }

        // POST: api/StockItem
        [HttpPost, Route("Stocks/Item/Add")]
        public IHttpActionResult AddStockItem(StockItemModel entity) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _StockItemService.Add(entity) 
                            && _StockItemService.Save())));
        }

        // PUT: api/StockItem/5
        [HttpPut, Route("Stocks/Item/Update")]
        public IHttpActionResult UpdateStockItem(StockItemModel entity) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _StockItemService.Update(entity) 
                            && _StockItemService.Save())));
        }

        // PUT: api/StockItem/5
        [HttpDelete, Route("Stocks/Item/Delete")]
        public IHttpActionResult DeleteStockItem(Guid id) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _StockItemService.Delete(id) 
                            && _StockItemService.Save())));
        }
        #endregion

        #region Stock Item Category
        // GET: api/StockItem
        [HttpGet, Route("Stocks/Category/")]
        public IHttpActionResult GetStockItemCategories() {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _StockItemCategoryService.Get())));
        }

        // POST: api/StockItem
        [HttpPost, Route("Stocks/Category/Add")]
        public IHttpActionResult AddStockItemCateogry(StockItemCategoryModel entity) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _StockItemCategoryService.Add(entity) 
                            && _StockItemCategoryService.Save())));
        }

        // PUT: api/StockItem/5
        [HttpPut, Route("Stocks/Category/Update")]
        public IHttpActionResult UpdateStockItemCategories(StockItemCategoryModel entity) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _StockItemCategoryService.Update(entity) 
                            && _StockItemCategoryService.Save())));
        }

        // PUT: api/StockItem/5
        [HttpPut, Route("Stocks/Category/Delete/{id}")]
        public IHttpActionResult DeleteStockItemCategories(Guid id) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _StockItemCategoryService.Delete(id) 
                            && _StockItemCategoryService.Save())));
        }
        #endregion

    }

}
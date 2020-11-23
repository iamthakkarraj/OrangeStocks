using OrangeStocks.API.Controller;
using OrangeStocks.BLL.Interfaces;
using OrangeStocks.Core.Entity;
using OrangeStocks.Core.Entity.View;
using OrangeStocks.Core.Utility;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrangeStocks.API.Controllers {

    public class TransactionController : OrangeStocksBaseController {

        private readonly IOrangeStocksCRUDService<TransactionModel> _TransactionCRUDService;
        private readonly IOrangeStocksCRUDService<TransactionDetailModel> _TransactionDetailCRUDService;
        private readonly IOrangeStocksCRUDService<TransactionTypeModel> _TransactionTypeCRUDService;

        public TransactionController(
                ICRUDServiceFactory<TransactionModel> _TransactionCRUDService,
                ICRUDServiceFactory<TransactionDetailModel> _TransactionDetailCRUDService,
                ICRUDServiceFactory<TransactionTypeModel> _TransactionTypeCRUDService ) {
            this._TransactionCRUDService = _TransactionCRUDService.GetService();
            this._TransactionDetailCRUDService = _TransactionDetailCRUDService.GetService();
            this._TransactionTypeCRUDService = _TransactionTypeCRUDService.GetService(); 
        }

        #region Transaction

        // GET: api/Transaction
        [HttpGet, Route("Transaction/")]
        public IHttpActionResult GetTransactions() {
            return TryResult(
                        ResponseMessage(
                            Request.CreateResponse(HttpStatusCode.OK,
                                _TransactionCRUDService.Get())));
        }

        // GET: api/Transaction/{GUID}
        [HttpGet, Route("Transaction/{id}")]
        public IHttpActionResult GetTransaction(Guid id) {
            return TryResult(
                    ResponseMessage(
                        Request.CreateResponse(HttpStatusCode.OK, 
                            _TransactionCRUDService.Get(id))));
        }

        // POST: api/Transaction
        [HttpPost, Route("Transaction/Add")]
        public IHttpActionResult PostTransaction(TransactionViewModel entity) {
            return TryResult(
                ResponseMessage(
                    Request
                    .CreateResponse(HttpStatusCode.OK, 
                        entity != null
                            && entity.TransactionModel != null
                            && entity.TransactionDetailModel != null
                            && _TransactionCRUDService.Add(entity.TransactionModel)                            
                            && _TransactionDetailCRUDService.Add(entity.TransactionDetailModel)                                
                            && _TransactionDetailCRUDService.Save())
                    )
                );
        }

        // PUT: api/Transaction/5
        [HttpPut, Route("Transaction/Update")]
        public IHttpActionResult PutTransaction(TransactionViewModel entity) {
            return TryResult(
                ResponseMessage(
                    Request
                    .CreateResponse(HttpStatusCode.OK,
                        entity != null
                            && entity.TransactionModel != null
                            && entity.TransactionDetailModel != null
                            && _TransactionCRUDService.Update(entity.TransactionModel)                            
                            && _TransactionDetailCRUDService.Update(entity.TransactionDetailModel)
                            && _TransactionDetailCRUDService.Save())
                    )
                );
        }

        // DELETE: api/Transaction/5
        [HttpDelete, Route("Transaction/Delete")]
        public IHttpActionResult DeleteTransaction(Guid id) {
            return TryResult(
                ResponseMessage(
                    Request
                    .CreateResponse(HttpStatusCode.OK,
                    _TransactionDetailCRUDService.Get()
                        .Where(x => x.InwardId == id)
                        .FirstOrDefault() != null
                        && _TransactionDetailCRUDService
                            .Delete(
                            _TransactionDetailCRUDService
                                .Get()                                
                                .Where(x => x.InwardId == id)                                
                                .First().InwardId)
                        && _TransactionDetailCRUDService.Save()                        
                        && _TransactionCRUDService.Delete(id)
                        && _TransactionCRUDService.Save())
                    )
                );
        }

        #endregion

        #region Transaction Details
        
        // GET: api/Transaction/{GUID}
        [HttpGet, Route("Transaction/{id}/Details")]
        public IHttpActionResult GetTransactionDetails(Guid id) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK, 
                        _TransactionDetailCRUDService.Get(id))));
        }
        
        // PUT: api/Transaction/5
        [HttpPost, Route("Transaction/{id}/Details/Update")]
        public IHttpActionResult Put(TransactionDetailModel entity) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _TransactionDetailCRUDService.Update(entity)
                        && _TransactionDetailCRUDService.Save())));
        }
        
        #endregion

        #region Transaction Types
        // GET: api/Transaction
        [HttpGet, Route("Transaction/Types")]
        public IHttpActionResult GetTransactionTypes() {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK, 
                        _TransactionTypeCRUDService.Get())));
        }

        // GET: api/Transaction/{GUID}
        [HttpGet, Route("Transaction/Types/{id}")]
        public IHttpActionResult GetTransactionType(Guid id) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK, 
                        _TransactionTypeCRUDService.Get(id))));
        }

        // Post: api/Transaction/Add
        [HttpPost, Route("Transaction/Types/Add")]
        public IHttpActionResult AddTransactionType(TransactionTypeModel entity) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _TransactionTypeCRUDService.Add(entity) 
                            && _TransactionTypeCRUDService.Save())));
        }

        // Post: api/Transaction/Add
        [HttpDelete, Route("Transaction/Types/Delete")]
        public IHttpActionResult DeleteTransactionType(Guid id) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _TransactionTypeCRUDService.Delete(id)
                            && _TransactionTypeCRUDService.Save())));
        }
        #endregion

    }

}

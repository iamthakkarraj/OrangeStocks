using OrangeStocks.API.Controller;
using OrangeStocks.BLL.Interfaces;
using OrangeStocks.Core.Entity;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrangeStocks.API.Controllers {

    public class CustomerController : OrangeStocksBaseController {

        private readonly IOrangeStocksCRUDService<CustomerModel> _CRUDService;

        public CustomerController(ICRUDServiceFactory<CustomerModel> _CRUDFactory) {
            this._CRUDService = _CRUDFactory.GetService();
        }

        // GET: api/Customer
        [HttpGet, Route("Customer/")]
        public IHttpActionResult Get() {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _CRUDService.Get())));
        }

        // GET: api/Customer/{GUID}
        [HttpGet, Route("Customer/{id}")]
        public IHttpActionResult Get(Guid id) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _CRUDService.Get(id))));
        }

        // POST: api/Customer
        [HttpPost, Route("Customer/Add")]
        public IHttpActionResult Post(CustomerModel entity) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _CRUDService.Add(entity) && _CRUDService.Save())));
        }

        // PUT: api/Customer/5
        [HttpPut, Route("Customer/Update")]
        public IHttpActionResult Put(CustomerModel entity) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _CRUDService.Update(entity) && _CRUDService.Save())));
        }

        // DELETE: api/Customer/5
        [HttpDelete, Route("Customer/Delete")]
        public IHttpActionResult Delete(Guid id) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _CRUDService.Delete(id) && _CRUDService.Save())));
        }

    }

}
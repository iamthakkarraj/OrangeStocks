using OrangeStocks.API.Controller;
using OrangeStocks.BLL.Interfaces;
using OrangeStocks.Core.Entity;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrangeStocks.API.Controllers {

    public class VendorController : OrangeStocksBaseController {

        private readonly IOrangeStocksCRUDService<VendorModel> _CRUDService;

        public VendorController(ICRUDServiceFactory<VendorModel> _CRUDFactory) { 
            this._CRUDService = _CRUDFactory.GetService(); 
        }

        // GET: api/Vendor
        [HttpGet, Route("Vendor/")]
        public IHttpActionResult Get() {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK, 
                        _CRUDService.Get())));
        }

        // GET: api/Vendor/{GUID}
        [HttpGet, Route("Vendor/{id}")]
        public IHttpActionResult Get(Guid id) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK, 
                        _CRUDService.Get(id))));
        }

        // POST: api/Vendor
        [HttpPost, Route("Vendor/Add")]
        public IHttpActionResult Post(VendorModel entity) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK, 
                        _CRUDService.Add(entity) && _CRUDService.Save())));
        }

        // PUT: api/Vendor/5
        [HttpPut, Route("Vendor/Update")]
        public IHttpActionResult Put(VendorModel entity) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK, 
                        _CRUDService.Update(entity) && _CRUDService.Save())));
        }

        // DELETE: api/Vendor/5
        [HttpDelete, Route("Vendor/Delete")]
        public IHttpActionResult Delete(Guid id) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK, 
                        _CRUDService.Delete(id) && _CRUDService.Save())));
        }

    }

}
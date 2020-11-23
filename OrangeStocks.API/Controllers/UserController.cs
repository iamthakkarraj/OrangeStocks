using OrangeStocks.API.Controller;
using OrangeStocks.BLL.Interfaces;
using OrangeStocks.Core.Entity;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrangeStocks.API.Controllers {

    public class UserController : OrangeStocksBaseController {

        private readonly IOrangeStocksCRUDService<UserModel> _CRUDService;

        public UserController(ICRUDServiceFactory<UserModel> _CRUDFactory) {
            this._CRUDService = _CRUDFactory.GetService();
        }

        // GET: api/User
        [HttpGet, Route("User/")]
        public IHttpActionResult Get() {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _CRUDService.Get())));
        }

        // GET: api/User/{GUID}
        [HttpGet, Route("User/{id}")]
        public IHttpActionResult Get(Guid id) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _CRUDService.Get(id))));
        }

        // POST: api/User
        [HttpPost, Route("User/Add")]
        public IHttpActionResult Post(UserModel entity) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _CRUDService.Add(entity) && _CRUDService.Save())));
        }

        // PUT: api/User/5
        [HttpPut, Route("User/Update")]
        public IHttpActionResult Put(UserModel entity) {
            return TryResult(
                ResponseMessage(Request
                    .CreateResponse(HttpStatusCode.OK,
                        _CRUDService.Update(entity) && _CRUDService.Save())));
        }
        
    }

}
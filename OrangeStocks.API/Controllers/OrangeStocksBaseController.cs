using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrangeStocks.API.Controller {

    public class OrangeStocksBaseController : ApiController {

        protected IHttpActionResult TryResult(IHttpActionResult httpActionResult) {
            try {
                return httpActionResult;
            } catch (Exception e) {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError));
            }
        }

    }

}

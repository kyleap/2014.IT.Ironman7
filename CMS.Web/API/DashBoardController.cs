using CMS.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMS.Web.API
{
    public class DashBoardController : ApiController
    {
        private DashBoardService service;

        public DashBoardController()
        {
            service = new DashBoardService();
        }

        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            var Datas = service.GetEmpOrders();
            return Request.CreateResponse(HttpStatusCode.OK, Datas);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
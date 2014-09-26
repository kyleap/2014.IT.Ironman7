using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMS.Web.API
{
    public class EmptyController : ApiController
    {
        // GET: api/Empty
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Empty/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Empty
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Empty/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Empty/5
        public void Delete(int id)
        {
        }
    }
}

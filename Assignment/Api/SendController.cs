using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment.Api
{
    public class SendController : ApiController
    {
        // GET: api/Send
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Send/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Send
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Send/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Send/5
        public void Delete(int id)
        {
        }
    }
}

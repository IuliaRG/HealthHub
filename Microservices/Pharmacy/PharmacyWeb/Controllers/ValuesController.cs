using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace PharmacyWeb.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        private PharmacySender messageToSend = new PharmacySender();
        private PharmacyReciver messageToRecive = new PharmacyReciver();
        [HttpGet]
        public string Get([FromServices] ILoggerManager loggerManager)
        {

            messageToSend.SendRequest();
            return "aaa";
          // return messageToRecive.ReciveRequest();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

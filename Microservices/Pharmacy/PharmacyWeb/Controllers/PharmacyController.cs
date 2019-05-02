using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PharmacyWeb.Controllers
{
    [Route("api/pharmacy")]
    public class PharmacyController : Controller
    {
        // GET api/values
        private PharmacySender messageToSend = new PharmacySender();
        private PharmacyReciver messageToRecive = new PharmacyReciver();
        [HttpGet]
        public string Get([FromServices] ILogger<PharmacyController> logger)
        {
            logger.LogInformation("Get values");
            messageToSend.SendRequest();
           // messageToRecive.ReciveRequest();
            return "aaa";
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

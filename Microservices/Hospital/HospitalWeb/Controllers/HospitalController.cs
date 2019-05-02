using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hospital.Controllers
{
    [Route("api/hospital")]
    public class HospitalController : Controller
    {
        // GET api/values
        private HospitalSender messageToSend = new HospitalSender();
        private HospitalReciver messageToRecive = new HospitalReciver();
        [HttpGet]
        public string Get([FromServices] ILogger<HospitalController> logger)
        {
            logger.LogInformation("Get values");
            var x= messageToRecive.ReciveRequest(); ;
            return "bbb";
           // messageToSend.SendRequest();
             
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

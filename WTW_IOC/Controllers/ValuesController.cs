using System;
using System.Collections.Generic;
using System.Web.Http;
using WTW_IOC.Logic.Logic;

namespace WTW_IOC.Web.Controllers
{
    public class ValuesController : ApiController
    {
        private ISampleLogic _sampleLogic;

        public ValuesController(ISampleLogic sampleLogic)
        {
            _sampleLogic = sampleLogic;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { _sampleLogic.AddMessage(1,2),
                                  _sampleLogic.SubtractMessage(5, 3),
                                  _sampleLogic.MultiplyMessage(99,99),
                                  _sampleLogic.DivideMessage(100, 10) };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return _sampleLogic.AddMessage(1, id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

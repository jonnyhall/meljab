using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using domain_meljab;
using domain_meljab.Abstract;
using domain_meljab.Concrete;

namespace dnn_webapi.Controllers
{
   [Authorize]
    public class MyLogController : ApiController
    {
        private IMyLogRepository repository;

        public MyLogController(IMyLogRepository _repository) {
            this.repository = _repository;
        }

        // GET api/values
        public IQueryable<dnn_YourCompany_LogEntry> Get()
        {
            return repository.Get();
        }


        // GET api/values/5
        public IQueryable<dnn_YourCompany_LogEntry> Get(string keyword)
        {
            return repository.Get(keyword);
        }

        // POST api/values
        public int Post([FromBody]dnn_YourCompany_LogEntry logEntry)
        {
            return repository.Post(logEntry);
        }

        // PUT api/values/5
        public void Put([FromBody]dnn_YourCompany_LogEntry logEntry)
        {
            repository.Put(logEntry);
        }

        // DELETE api/values/5
        public void Delete(int itemid)
        {
            repository.Delete(itemid);
        }
    }
}
